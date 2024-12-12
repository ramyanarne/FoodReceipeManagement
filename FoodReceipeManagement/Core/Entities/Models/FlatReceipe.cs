namespace FoodReceipeManagement.Core.Entities.Models
{
    public class FlatReceipe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public string Ingredient { get; set; }
        public double Quantity { get; set; }
        public string MeasurementUnit { get; set; }       
        public string Instructions { get; set; }
    }
}
