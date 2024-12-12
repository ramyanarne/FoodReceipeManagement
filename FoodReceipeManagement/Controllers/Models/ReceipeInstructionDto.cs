using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodReceipeManagement.Controllers.Models
{
    public class ReceipeInstructionDto
    {
        public int InstructionOrderId { get; set; }
        public string Instruction { get; set; }
    }
}
