using FoodReceipeManagement.Core.Contracts;
using FoodReceipeManagement.Core.Entities;
using FoodReceipeManagement.Core.Entities.Models;

namespace FoodReceipeManagement.Core.Repository
{
    public class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(ApplicationContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
