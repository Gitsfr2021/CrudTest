using Mc2.Application.Common.Interfaces;
using Mc2.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.Application.Services.Customer.Commands
{
    public class DeleteCustomerResultDto
    {
        public long Id { get; set; }
    }
    public class DeleteCustomerRequestDto
    {
        public int Id { get; set; }
    }
    public interface IDeleteCustomerService
    {
        ResultDto<int> Execute(int Id);
    }
    public class DeleteCustomerService : IDeleteCustomerService
    {
        private readonly IDataBaseContext _context;
        public DeleteCustomerService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<int> Execute(int Id)
        {
            var item = _context.Customers.Find(Id);
            _context.SaveChanges();
            ResultDto<int> result = new ResultDto<int>();
            result.Data = item.Id;
            result.IsSuccess = true;
            return result;
        }
    }
}
