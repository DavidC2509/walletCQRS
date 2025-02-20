using AutoMapper;
using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.MovementTransferAggregate;
using Template.Domain.MovementTransferAggregate.Specification;
using Template.Services.Models;

namespace Template.Services.Query.MovementTransfers
{
    public class ListMovementTransferQueryHandler : BaseQueryHandler<MovementTransfer, ListMovementTransferQuery, IEnumerable<MovementTransferModel>>
    {
        private readonly IMapper _mapper;

        public ListMovementTransferQueryHandler(IReadRepository<MovementTransfer> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async override Task<IEnumerable<MovementTransferModel>> Handle(ListMovementTransferQuery request, CancellationToken cancellationToken)
        {
            var specMovementTransfer = new MovementTransferListSpec(request.StartDate, request.EndDate, request.AccountId);

            var list = await _repository.ListAsync(specMovementTransfer, cancellationToken);
            Console.WriteLine("Obtuvo listado : " + list.Count);

            var resultMapper = _mapper.Map<List<MovementTransferModel>>(list);
            return resultMapper;
        }
    }
}