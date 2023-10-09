using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.ClassifiersAggregate;
using Template.Services.Command.Users;
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
