using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodReceipeManagement.Core.Entities.Models
{
    [Table("Receipe")]
    public class Receipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReceipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public IEnumerable<ReceipeIngredient> ReceipeIngredients { get; set; }
        public IEnumerable<ReceipeInstruction> ReceipeInstructions { get; set; }
    }
}
