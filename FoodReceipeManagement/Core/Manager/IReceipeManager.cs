using FluentResults;
using FoodReceipeManagement.Core.Entities.Models;

namespace FoodReceipeManagement.Core.Manager
{
    public interface IReceipeManager
    {
        Task<IEnumerable<Receipe>> GetAllReceipesAsync();
        Task<Result<Receipe>> GetReceipeByIdAsync(int id);
        Task AddReceipe(Receipe receipe);
        Task UpdateReceipe(Receipe receipe);
        Task<Result> DeleteReceipe(int id);
        Task BackFillData();
    }
}