using AutoMapper;
using Template.Domain.MovementTransferAggregate;
using Template.Services.Models;

namespace Template.Services.Mapper
{
    public class MovementTransferProfile : Profile
    {
        public MovementTransferProfile()
        {
            CreateMap<MovementTransfer, MovementTransferModel>();
        }
    }
}
