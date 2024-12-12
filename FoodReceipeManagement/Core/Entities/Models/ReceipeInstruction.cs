using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodReceipeManagement.Core.Entities.Models
{
    public class ReceipeInstruction
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReceipeInstructionId { get; set; }
        public int ReceipeId { get; set; }
        public Receipe Receipe { get; set; }
        public int InstructionOrderId { get; set; }
        public string Instruction { get; set; }
    }
}
