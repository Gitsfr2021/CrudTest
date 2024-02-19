using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.Application.Common.Dto
{
    public class RequestGetAllCustomerDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public List<ResultGetAllItemDto>? Customer { get; set; }
    }
}
