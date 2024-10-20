using AutoMapper;
using Template.Domain.ClassifiersAggregate;
using Template.Services.Models;

namespace Template.Services.Mapper
{
    public class DeafultParameterMappingProfile : Profile
    {
        public DeafultParameterMappingProfile()
        {
            CreateMap<CategoryGlobal, CategoryAccount>();
            CreateMap<CategoryMovementGlobal, CategoryMovement>();


            CreateMap<CategoryAccount, ClassifierModel>();
            CreateMap<CategoryMovement, ClassifierModel>();

        }
    }
}
