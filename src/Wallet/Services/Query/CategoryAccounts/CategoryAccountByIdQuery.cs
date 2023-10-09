using MediatR;
using Template.Services.Models;

namespace Template.Services.Query.CategoryAccounts
{
    public class CategoryAccountByIdQuery : IRequest<ClassifierModel>
    {
        public Guid Id { get; set; }

        public CategoryAccountByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}