using Azure.Core;
using Mc2.Application.Common.Dto;
using Mc2.Application.Common.Interfaces;
using Mc2.Application.Services.Customer.Commands;
using Mc2.Application.Services.Customer.Queries;
using Mc2.Common.Dto;
using Mc2.CrudTest.Presentation.Client.Pages;
using Mc2.CrudTest.Presentation.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IGetAllCustomerService _getAllCustomerService;
        private readonly IDataBaseContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
       // private readonly IMediator _mediator;

        //IMediator mediator,
        public CustomerController(IDataBaseContext context, IDeleteCustomerService deleteCustomerService, IEditCustomerService editCustomerService, IAddCustomerService addCustomerService, IGetAllCustomerService getAllCustomerService, IGetCustomerService getCustomerService, IWebHostEnvironment webHostEnvironment)
        {
            _getAllCustomerService = getAllCustomerService;
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
           // _mediator = mediator;
        }

        [HttpGet]
        public ResultDto<RequestGetAllCustomerDto> GetAll()
        {
            // var request = new RequestGetAllCustomerDto();
            var request = new RequestGetAllCustomerDto
            {
                Id = 1,
                FirstName = "John",
                PageNumber = 1,
                PageSize = 10,
                RowCount = 100,
                Customer = new List<ResultGetAllItemDto>{
        new ResultGetAllItemDto { FirstName = "Alice", LastName = "Smith" },
        new ResultGetAllItemDto { FirstName = "Bob", LastName = "Johnson" }
     
             }
            };
            return _getAllCustomerService.Execute(request, 1, 20);
        }
    }
}

