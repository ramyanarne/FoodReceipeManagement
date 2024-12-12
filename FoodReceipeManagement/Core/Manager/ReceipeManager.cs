using CsvHelper;
using System.Globalization;
using FluentResults;
using FoodReceipeManagement.Core.Contracts;
using FoodReceipeManagement.Core.CustomError;
using FoodReceipeManagement.Core.Entities;
using FoodReceipeManagement.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;
using CsvHelper.Configuration;

namespace FoodReceipeManagement.Core.Manager
{
    public class ReceipeManager : IReceipeManager
    {
        private readonly IReceipeRepository _receipeRepository;
        private readonly ApplicationContext _applicationContext;
        private readonly ILoggerManager _logger;
        public ReceipeManager(IReceipeRepository receipeRepository, ApplicationContext applicationContext, ILoggerManager logger)
        {
            _receipeRepository = receipeRepository ?? throw new ArgumentNullException(nameof(receipeRepository));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public async Task AddReceipe(Receipe receipe)
        {
            _receipeRepository.AddReceipe(receipe);
            await SaveAsync();
        }

        public async Task UpdateReceipe(Receipe receipe)
        {
            _receipeRepository.UpdateReceipe(receipe);
            await SaveAsync();
        }

        public async Task<Result> DeleteReceipe(int id)
        {
            var receipe = _applicationContext.Receipes.Include(x => x.ReceipeIngredients).Include(x => x.ReceipeInstructions).FirstOrDefault(s => s.ReceipeId.Equals(id));

            if (receipe == null)
            {
                _logger.LogError($"Receipe with id: {id}, hasn't been found.");
                return new RecordNotFoundError();
            }
            _receipeRepository.DeleteReceipe(receipe);
            await SaveAsync();
            return Result.Ok();
        }

        public Task<IEnumerable<Receipe>> GetAllReceipesAsync() => _receipeRepository.GetAllReceipesAsync();

        public async Task<Result<Receipe>> GetReceipeByIdAsync(int id)
        {
            var receipe = await _receipeRepository.GetReceipeByIdAsync(id);

            if (receipe == null)
            {
                _logger.LogError($"Receipe with id: {id}, hasn't been found.");
                return new RecordNotFoundError();
            }
            return Result.Ok(receipe);
        }

        private async Task SaveAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }

        public async Task BackFillData()
        {
            var result = new List<Receipe>();
            var ingredients = new List<Ingredient>();
            var measurementUnits = new List<MeasurementUnit>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = "|"
            };
            using (var reader = new StreamReader("yourfilepath"))
            using (var csv = new CsvReader(reader, config))
            {
                var receipes = csv.GetRecords<FlatReceipe>().GroupBy(x => new { x.Name, x.Description, x.CookingTime });
                foreach (var flatReceipe in receipes)
                {
                    var instructions = flatReceipe.Select(x => x.Instructions).FirstOrDefault()?.Split(".", StringSplitOptions.RemoveEmptyEntries);
                    List<ReceipeInstruction> receipeInstructions = new List<ReceipeInstruction>();
                    int i = 0;
                    foreach (var instruction in instructions)
                    {
                        receipeInstructions.Add(new ReceipeInstruction
                        {
                            Instruction = instruction,
                            InstructionOrderId = i++
                        });
                    }

                    var ingredientData = flatReceipe.GroupBy(x => new { x.Ingredient, x.Quantity, x.MeasurementUnit });
                    List<ReceipeIngredient> receipeIngredients = new List<ReceipeIngredient>();
                    foreach (var ingredient in ingredientData)
                    {
                        var reciepeIngredient = new ReceipeIngredient();
                        reciepeIngredient.Quantity = ingredient.Key.Quantity;
                        reciepeIngredient.Ingredient = new Ingredient { Name = ingredient.Key.Ingredient };
                        reciepeIngredient.MeasurementUnit = new MeasurementUnit { Name = ingredient.Key.MeasurementUnit };
                        receipeIngredients.Add(reciepeIngredient);
                        ingredients.Add(new Ingredient { Name = ingredient.Key.Ingredient });
                        measurementUnits.Add(new MeasurementUnit { Name = ingredient.Key.MeasurementUnit });
                    }
                    var receipe = new Receipe
                    {
                        Name = flatReceipe.Key.Name,
                        Description = flatReceipe.Key.Description,
                        CookingTime = flatReceipe.Key.CookingTime,
                        ReceipeInstructions = receipeInstructions,
                        ReceipeIngredients = receipeIngredients
                    };
                    result.Add(receipe);
                }
            }

            _receipeRepository.AddIngredients(ingredients.DistinctBy(x=>x.Name, StringComparer.OrdinalIgnoreCase).ToList());
            _receipeRepository.AddMeasurementUnits(measurementUnits.DistinctBy(x=>x.Name, StringComparer.OrdinalIgnoreCase).ToList());
                
            await SaveAsync();

            foreach(var receipe in result)
            {
                foreach (var ingredient in receipe.ReceipeIngredients)
                {
                    ingredient.IngredientId = _receipeRepository.GetIngredientIdByName(ingredient.Ingredient.Name);
                    ingredient.Ingredient = default;
                    ingredient.MeasurementUnitId = _receipeRepository.GetMeasurementUnitIdByName(ingredient.MeasurementUnit.Name);
                    ingredient.MeasurementUnit = default;
                }
            }
            _receipeRepository.AddReceipes(result);
            await SaveAsync();

        }
    }
}
