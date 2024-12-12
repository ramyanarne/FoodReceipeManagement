using FoodReceipeManagement.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodReceipeManagement.Core.Entities.Configuration
{
    public class ReceipeInstructionsConfiguration : IEntityTypeConfiguration<ReceipeInstruction>
    {
        public void Configure(EntityTypeBuilder<ReceipeInstruction> builder)
        {
            builder.ToTable("ReceipeInstructions");
            builder.HasData(
                new ReceipeInstruction
                {
                    ReceipeInstructionId = 1,
                    ReceipeId = 1,
                    InstructionOrderId = 1,
                    Instruction = "Gather the ingredients. Preheat the oven to 450 degrees F (230 degrees C)"
                }, new ReceipeInstruction
                {
                    ReceipeInstructionId = 2,
                    ReceipeId = 1,
                    InstructionOrderId = 2,
                    Instruction = "Line a 9-inch pie dish with one pastry crust; set second one aside."
                }, new ReceipeInstruction
                {
                    ReceipeInstructionId = 3,
                    ReceipeId = 1,
                    InstructionOrderId = 3,
                    Instruction = "Combine 3/4 cup sugar and cinnamon in a small bowl. Add more sugar if your apples are tart"
                }, new ReceipeInstruction
                {
                    ReceipeInstructionId = 4,
                    ReceipeId = 1,
                    InstructionOrderId = 4,
                    Instruction = "Layer apple slices in the prepared pie dish, sprinkling each layer with cinnamon-sugar mixture"
                }, new ReceipeInstruction
                {
                    ReceipeInstructionId= 5,
                    ReceipeId = 1,
                    InstructionOrderId = 5,
                    Instruction = "Dot top layer with small pieces of butter. Cover with top crust"
                }, new ReceipeInstruction
                {
                    ReceipeInstructionId = 6,
                    ReceipeId = 1,
                    InstructionOrderId = 6,
                    Instruction = "Bake pie on the lowest rack of the preheated oven for 10 minutes. Reduce oven temperature to 350 degrees F (175 degrees C) and continue baking until golden brown and filling bubbles, 30 to 35 minutes more"
                }, new ReceipeInstruction
                {
                    ReceipeInstructionId = 7,
                    ReceipeId = 1,
                    InstructionOrderId = 7,
                    Instruction = "Serve warm or cold."
                }
                );
        }
    }
}
