using System.ComponentModel.DataAnnotations.Schema;

namespace FoodReceipeManagement.Core.Entities.Models
{
    public class MeasurementUnit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeasurementUnitId { get; set; }
        public string Name { get; set; }
    }
}
