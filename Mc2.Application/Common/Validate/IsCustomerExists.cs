using MediatR;

namespace Mc2.CrudTest.Application.Common.Validate
{
    public record IsCustomerExistsQuery : IRequest<bool>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}
