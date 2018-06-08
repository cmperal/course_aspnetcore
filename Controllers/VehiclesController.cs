using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private IVehicleRepository repository;
        private IUnitOfWork unitOfWork;

        public VehiclesController(IMapper mapper, IVehicleRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle ([FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);

            vehicle.LastUpdate = DateTime.Now;

            repository.Add(vehicle);

            await unitOfWork.CompleteAsync();

            vehicle = await repository.GetVehicle(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result); 

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle (int id, [FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

             var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
               return NotFound();

            mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);

            vehicle.LastUpdate = DateTime.Now;           

            await unitOfWork.CompleteAsync();            

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result); 

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id, includeRelated: false);

            if (vehicle == null)
                return NotFound();

            repository.Remove(vehicle);

            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
           var vehicle = await repository.GetVehicle(id);
           
            if (vehicle == null)
                return NotFound();
            
            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);

        }
    }
}