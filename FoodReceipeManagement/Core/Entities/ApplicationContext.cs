using FoodReceipeManagement.Core.Entities.Configuration;
using FoodReceipeManagement.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodReceipeManagement.Core.Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }
        public DbSet<Receipe> Receipes { get; set; }

        public DbSet<Ingredient> Ingredient { get; set; }

        public DbSet<MeasurementUnit> MeasurementUnit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration(new MeasurementUnitConfiguration());
            modelBuilder.ApplyConfiguration(new ReceipeConfiguration());
            modelBuilder.ApplyConfiguration(new ReceipeIngredientsConfiguration());
            modelBuilder.ApplyConfiguration(new ReceipeInstructionsConfiguration());
        }
    }
}
