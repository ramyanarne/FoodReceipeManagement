using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodReceipeManagement.Core.Entities.Models
{
    public class ReceipeIngredient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReceipeIngredientId { get; set; }
        public int ReceipeId { get; set; }
        public Receipe Receipe { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public double Quantity { get; set; }
        public int MeasurementUnitId { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }

    }
}
