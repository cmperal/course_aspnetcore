namespace vega.Models
{
    public class Model
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Index (navigation) property.
        public Make Make { get; set; }

        //MakeId is the foreign key used for avoiding query the DB to retrieve the ID and associate it with Model.cs
        public int MakeId { get; set; }
    }
}