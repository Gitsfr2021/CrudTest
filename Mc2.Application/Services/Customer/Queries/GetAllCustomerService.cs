using Mc2.Application.Common.Dto;
using Mc2.Application.Common.Interfaces;
using Mc2.Common.Dto;
using Mc2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.Application.Services.Customer.Queries
{
    public interface IGetAllCustomerService
    {
        ResultDto<RequestGetAllCustomerDto> Execute(RequestGetAllCustomerDto request, int Page = 1, int PageSize = 1);
    }
    public class GetAllCustomerService : IGetAllCustomerService
    {
        private readonly IDataBaseContext _context;
        public GetAllCustomerService(IDataBaseContext context)
        {
            _context = context;
        }
        //public List<ResultGetAllServiceDto> Execute(RequestGetAllServiceDto request)
        public ResultDto<RequestGetAllCustomerDto> Execute(RequestGetAllCustomerDto request, int Page = 1, int PageSize = 1)
        {
            {
                int rowCount = 0;
                var Customer = _context.Customers

                      .Select(p => new ResultGetAllItemDto
                      {
                          Id = p.Id,
                          FirstName = p.FirstName,
                         LastName = p.LastName,
                          Email = p.Email,
                          PhoneNumber = p.PhoneNumber
                      }).OrderByDescending(p => p.Id)
                       .ToPaged(Page, PageSize, out rowCount)
                       .ToList();

                return new ResultDto<RequestGetAllCustomerDto>()
                {
                    Data = new RequestGetAllCustomerDto()
                    {
                        Customer = Customer,
                        PageNumber = Page,
                        PageSize = PageSize,
                        RowCount = rowCount
                    },
                    IsSuccess = true,
                    Message = "",
                };
            }

        }
    }
}
