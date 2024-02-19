using MediatR;

namespace Mc2.CrudTest.Application.Common.Validate
{
    public record IsCustomerEmailExistsQuery : IRequest<bool>
    {
        public string? Email { get; set; }
    }
}
