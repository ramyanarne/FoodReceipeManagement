using FoodReceipeManagement.Core.Contracts;
using FoodReceipeManagement.Core.Entities;
using FoodReceipeManagement.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodReceipeManagement.Core.Repository
{
    public class ReceipeRepository : RepositoryBase<Receipe>, IReceipeRepository
    {
        private readonly ApplicationContext _applicationContext;
        public ReceipeRepository(ApplicationContext repositoryContext) : base(repositoryContext)
        {
            _applicationContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }

        public async Task<IEnumerable<Receipe>> GetAllReceipesAsync()
        {
            return await FindAll().Include(x=>x.ReceipeInstructions)
                .Include(x=>x.ReceipeIngredients)
                 .ThenInclude(x=> x.Ingredient)
                .Include(x=>x.ReceipeIngredients)
                 .ThenInclude(x=>x.MeasurementUnit)
                .OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Receipe> GetReceipeByIdAsync(int id)
        {
            return await FindByCondition(x => x.ReceipeId.Equals(id)).Include(x => x.ReceipeInstructions)
                .Include(x => x.ReceipeIngredients)
                 .ThenInclude(x => x.Ingredient)
                .Include(x => x.ReceipeIngredients)
                 .ThenInclude(x => x.MeasurementUnit).FirstOrDefaultAsync();
        }

        public void AddReceipe(Receipe receipe)
        {
            Create(receipe);
        }

        public void UpdateReceipe(Receipe receipe)
        {
            Update(receipe);
        }

        public void DeleteReceipe(Receipe receipe)
        {
            Delete(receipe);
        }

        public void AddReceipes(List<Receipe> receipes)
        {
            _applicationContext.Set<Receipe>().AddRange(receipes);
        }

        public void AddIngredients(List<Ingredient> ingredients)
        {
            _applicationContext.Set<Ingredient>().AddRange(ingredients);
        }

        public void AddMeasurementUnits(List<MeasurementUnit> measurementUnits)
        {
            _applicationContext.Set<MeasurementUnit>().AddRange(measurementUnits);
        }

        public int GetIngredientIdByName(string name)
        {
            return _applicationContext.Ingredient.Where(x => x.Name.ToLower().Equals(name.ToLower())).Select(x => x.IngredientId).FirstOrDefault();
        }

        public int GetMeasurementUnitIdByName(string name)
        {
            return _applicationContext.MeasurementUnit.Where(x => x.Name.ToLower().Equals(name.ToLower())).Select(x => x.MeasurementUnitId).FirstOrDefault();
        }
    }
}
