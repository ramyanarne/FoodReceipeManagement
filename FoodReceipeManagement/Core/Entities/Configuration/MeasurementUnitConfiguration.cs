using FoodReceipeManagement.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodReceipeManagement.Core.Entities.Configuration
{
    public class MeasurementUnitConfiguration : IEntityTypeConfiguration<MeasurementUnit>
    {
        public void Configure(EntityTypeBuilder<MeasurementUnit> builder)
        {
            builder.ToTable("MeasurementUnit").HasIndex(x=>x.Name).IsUnique();
            builder.HasData(
                new MeasurementUnit
                {
                    MeasurementUnitId = 1,
                    Name = "Ounce"
                },   new MeasurementUnit
                {
                    MeasurementUnitId = 2,
                    Name = "Tablespoon"
                },   new MeasurementUnit
                {
                    MeasurementUnitId = 3,
                    Name = "Teaspoon"
                },   new MeasurementUnit
                {
                    MeasurementUnitId = 4,
                    Name = "Cups"
                }, new MeasurementUnit
                {
                    MeasurementUnitId = 5,
                    Name = "Cup"
                }
                );
        }
    }
}
