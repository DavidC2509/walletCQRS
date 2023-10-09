using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.MovementAggregate;
using Template.Domain.UserAggregate;
using Template.Services.Command.Users;
using Template.Services.Models;

namespace Template.Services.Mapper
{
    public class MovementTransferProfile : Profile
    {
        public MovementTransferProfile()
        {
            CreateMap<MovementTransferModel, MovementTransfer>();
        }
    }
}
