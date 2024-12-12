using FoodReceipeManagement.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodReceipeManagement.Core.Entities.Configuration
{
    public class ReceipeIngredientsConfiguration : IEntityTypeConfiguration<ReceipeIngredient>
    {
        public void Configure(EntityTypeBuilder<ReceipeIngredient> builder)
        {
            builder.ToTable("ReceipeIngredients");
            builder.HasData(
                new ReceipeIngredient
                {
                    ReceipeIngredientId = 1,
                    ReceipeId = 1,
                    IngredientId = 1,
                    MeasurementUnitId = 4,
                    Quantity = 6
                },
                new ReceipeIngredient
                {
                    ReceipeIngredientId = 2,
                    ReceipeId = 1,
                    IngredientId = 2,
                    MeasurementUnitId = 5,
                    Quantity= 0.75
                }, new ReceipeIngredient
                {
                    ReceipeIngredientId= 3,
                    ReceipeId = 1,
                    IngredientId = 3,
                    MeasurementUnitId = 3,
                    Quantity = 1
                }, new ReceipeIngredient
                {
                    ReceipeIngredientId = 4,
                    ReceipeId = 1,
                    IngredientId = 4,
                    MeasurementUnitId = 1,
                    Quantity = 14.1
                },
                new ReceipeIngredient
                {
                    ReceipeIngredientId = 5,
                    ReceipeId = 1,
                    IngredientId = 5,
                    MeasurementUnitId = 2,
                    Quantity = 1
                }
            );
        }
    }
}
