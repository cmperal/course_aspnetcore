using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using vega.Models;
using vega.Controllers.Resources;

namespace vega.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }

        public ModelResource Model {get; set;}   

        public bool IsRegistered { get; set; }

        public ContactResource Contact { get; set; }
        
        public DateTime LastUpdate { get; set; }   

        public ICollection<FeatureResource> Features { get; set; }

        public VehicleResource()
        {
            Features = new Collection<FeatureResource>();
        }
    }
}