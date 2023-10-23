using AutoMapper;
using Core.CommandAndQueryHandler;
using Core.Domain.Repository;
using Template.Domain.AccountAggregate;
using Template.Domain.MovementAggregate;
using Template.Domain.MovementTransferAggregate;
using Template.Domain.Specification;
using Template.Services.Models;

namespace Template.Services.Query.MovementTransfers
{
    public class MovementTransferByIdQueryHandler : BaseQueryHandler<MovementTransfer, MovementTransferByIdQuery, MovementTransferModel>
    {
        private readonly IMapper _mapper;

        public MovementTransferByIdQueryHandler(IReadRepository<MovementTransfer> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async override Task<MovementTransferModel> Handle(MovementTransferByIdQuery request, CancellationToken cancellationToken)
        {
            var movementTransfer = await _repository.GetByIdAsync(request.Id, cancellationToken);

            var resultMapper = _mapper.Map<MovementTransferModel>(movementTransfer);
            return resultMapper;
        }
    }
}