using System.ComponentModel.DataAnnotations;

namespace FoodReceipeManagement.Controllers.Models
{
    public class ReceipeForAddDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Cooking Time is required")]
        public int CookingTime { get; set; }
        public string Description { get; set; }
        public IEnumerable<ReceipeIngredientDto> ReceipeIngredients { get; set; }
        public IEnumerable<ReceipeInstructionDto> ReceipeInstructions { get; set; }
    }
}
