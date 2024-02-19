using Mc2.Application.Common.Interfaces;
using Mc2.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.Application.Services.Customer.Commands
{
    public class AddCustomerResultDto
    {
        public int Id { get; set; }
    }
    public class AddCustomerRequestDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? BankAccountNumber { get; set; }
    }

    public interface IAddCustomerService
    {
        ResultDto<int> Execute(AddCustomerRequestDto request);
    }

    public class AddCustomerService : IAddCustomerService
    {
        private readonly IDataBaseContext _context;
        public AddCustomerService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<int> Execute(AddCustomerRequestDto request)
        {
            var item = new Mc2.Domain.Entities.Customer();
            item.Id = request.Id;
            item.FirstName = request.FirstName;
            item.LastName = request.LastName;
            item.Email = request.Email;
            item.DateOfBirth = request.DateOfBirth;
            item.BankAccountNumber = request.BankAccountNumber;
            item.PhoneNumber = request.PhoneNumber;
            _context.Customers.Add(item);
            _context.SaveChanges();

            ResultDto<int> result = new ResultDto<int>();
            result.Data = item.Id;
            result.IsSuccess = true;
            return result;

        }
    }
}
