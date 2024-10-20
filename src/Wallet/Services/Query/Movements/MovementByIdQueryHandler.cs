using AutoMapper;
using Core.Cqrs.CommandAndQueryHandler;
using Core.Cqrs.Domain.Repository;
using Template.Domain.MovementAggregate;
using Template.Domain.MovementAggregate.Specification;
using Template.Services.Models;

namespace Template.Services.Query.Movements
{
    public class MovementByIdQueryHandler : BaseQueryHandler<Movement, MovementByIdQuery, MovementModel>
    {
        private readonly IMapper _mapper;

        public MovementByIdQueryHandler(IReadRepository<Movement> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async override Task<MovementModel> Handle(MovementByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new MovementByIdSpec(request.Id);
            var account = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

            var resultMapper = _mapper.Map<MovementModel>(account);
            return resultMapper;
        }
    }
}