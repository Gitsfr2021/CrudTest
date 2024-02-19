using Mc2.Application.Common.Dto;
using Mc2.Application.Common.Interfaces;
using Mc2.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.Application.Services.Customer.Queries
{
    public interface IGetCustomerService
    {
        ResultDto<ResultGetCustomerDto> Execute(int ID);
    }
    public class GetCustomerService : IGetCustomerService
    {
        private readonly IDataBaseContext _context;
        public GetCustomerService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultGetCustomerDto> Execute(int ID)
        {
            //query
            var item = _context.Customers.Find(ID);

            return new ResultDto<ResultGetCustomerDto>()
            {
                Data = new ResultGetCustomerDto()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    DateOfBirth = item.DateOfBirth
                },
                IsSuccess = true,
                Message = "",
            };


        }
    }
}
