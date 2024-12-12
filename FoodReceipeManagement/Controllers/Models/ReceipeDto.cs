using FoodReceipeManagement.Core.Entities;

namespace FoodReceipeManagement.Controllers.Models
{
    public class ReceipeDto
    {
        public int ReceipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; }
        public IEnumerable<ReceipeIngredientDto> ReceipeIngredients { get; set; }
        public IEnumerable<ReceipeInstructionDto> ReceipeInstructions { get; set; }
    }
}
