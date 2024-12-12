using System.ComponentModel.DataAnnotations;

namespace FoodReceipeManagement.Controllers.Models
{
    public class ReceipeIngredientDto
    {
        public int IngredientId { get; set; }
        public IngredientDto? Ingredient { get; set; }
        public int MeasurementUnitId { get; set; }
        public double Quantity { get; set; }
        public MeasurementUnitDto? MeasurementUnit { get; set; }

    }
}
