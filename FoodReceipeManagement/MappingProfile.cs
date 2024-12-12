using AutoMapper;
using FoodReceipeManagement.Controllers.Models;
using FoodReceipeManagement.Core.Entities.Models;

namespace FoodReceipeManagement
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Receipe, ReceipeDto>();
            CreateMap<ReceipeIngredient, ReceipeIngredientDto>().ReverseMap();
            CreateMap<ReceipeInstruction, ReceipeInstructionDto>().ReverseMap();
            CreateMap<Ingredient, IngredientDto>().ReverseMap();
            CreateMap<MeasurementUnit, MeasurementUnitDto>().ReverseMap();
            CreateMap<ReceipeForAddDto, Receipe>();
            CreateMap<ReceipeForUpdateDto, Receipe>();
        }
    }
}
