using FoodReceipeManagement.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodReceipeManagement.Core.Entities.Configuration
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("Ingredient").HasIndex(x=>x.Name).IsUnique();
            builder.HasData(
                new Ingredient
                {
                    IngredientId = 1,
                    Name = "Apples"
                },
                new Ingredient
                {
                    IngredientId = 2,
                    Name = "Sugar"
                },
                new Ingredient
                {
                    IngredientId = 3,
                    Name = "Cinnamon"
                },  
                 new Ingredient
                 {
                     IngredientId = 4,
                     Name = "Pie Dough"
                 },
                 new Ingredient
                 {
                     IngredientId = 5,
                      Name = "Butter"
                 }
                );
        }
    }
}
