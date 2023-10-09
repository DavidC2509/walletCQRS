using MediatR;
using Template.Services.Models;

namespace Template.Services.Query.CategoryMovements
{
    public class CategoryMovementByIdQuery : IRequest<ClassifierModel>
    {
        public Guid Id { get; set; }

        public CategoryMovementByIdQuery(Guid id){
            Id = id;
        }
    }
}