using FoodReceipeManagement.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodReceipeManagement.Core.Entities.Configuration
{
    public class ReceipeConfiguration : IEntityTypeConfiguration<Receipe>
    {
        public void Configure(EntityTypeBuilder<Receipe> builder)
        {
            builder.ToTable("Receipes").HasIndex(x=>x.Name).IsUnique();
            builder.HasData(
                new Receipe
                {
                    ReceipeId = 1,
                    Name = "Apple Pie",
                    Description = "Bake and cool the pie, and then top with vanilla ice cream for the ultimate dessert.",
                    CookingTime = 60
                }
                );
        }
    }
}
