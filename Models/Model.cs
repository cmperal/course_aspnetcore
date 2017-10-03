using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vega.Models
{
    [Table("Models")]
    public class Model
    {
        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //Index (navigation) property.
        public Make Make { get; set; }

        //MakeId is the foreign key used for avoiding query the DB to retrieve the ID and associate it with Model.cs
        public int MakeId { get; set; }
    }
}