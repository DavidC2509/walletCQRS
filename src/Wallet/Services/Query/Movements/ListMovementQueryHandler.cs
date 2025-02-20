using AutoMapper;
using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.MovementAggregate;
using Template.Domain.MovementAggregate.Specification;
using Template.Services.Models;

namespace Template.Services.Query.Movements
{
    public class ListMovementQueryHandler : BaseQueryHandler<Movement, ListMovementQuery, IEnumerable<MovementModel>>
    {
        private readonly IMapper _mapper;

        public ListMovementQueryHandler(IReadRepository<Movement> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async override Task<IEnumerable<MovementModel>> Handle(ListMovementQuery request, CancellationToken cancellationToken)
        {
            var specMovement = new MovementListSpec(request.StartDate, request.EndDate, request.AccountId, request.TypeMpvement);
            var list = await _repository.ListAsync(specMovement, cancellationToken);
            Console.WriteLine("Obtuvo listado : " + list.Count);

            var resultMapper = _mapper.Map<List<MovementModel>>(list);
            return resultMapper;
        }
    }
}