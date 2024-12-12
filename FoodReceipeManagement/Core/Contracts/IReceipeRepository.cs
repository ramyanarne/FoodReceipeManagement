using FoodReceipeManagement.Core.Entities.Models;

namespace FoodReceipeManagement.Core.Contracts
{
    public interface IReceipeRepository 
    {
        Task<IEnumerable<Receipe>> GetAllReceipesAsync();
        Task<Receipe> GetReceipeByIdAsync(int id);
        void AddReceipe(Receipe receipe);
        void UpdateReceipe(Receipe receipe);
        void DeleteReceipe(Receipe id);
        void AddReceipes(List<Receipe> receipes);
        void AddIngredients(List<Ingredient> ingredients);
        void AddMeasurementUnits(List<MeasurementUnit> measurementUnits);
        int GetIngredientIdByName(string name);
        int GetMeasurementUnitIdByName(string name);
    }
}
