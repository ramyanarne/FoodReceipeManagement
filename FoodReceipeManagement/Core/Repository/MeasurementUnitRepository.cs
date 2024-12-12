using FoodReceipeManagement.Core.Contracts;
using FoodReceipeManagement.Core.Entities;
using FoodReceipeManagement.Core.Entities.Models;

namespace FoodReceipeManagement.Core.Repository
{
    public class MeasurementUnitRepository : RepositoryBase<MeasurementUnit>, IMeasurementUnitRepository
    {
        public MeasurementUnitRepository(ApplicationContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
