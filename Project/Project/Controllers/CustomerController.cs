using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.BLL;
using Project.DAL;
using Project.Models;
using Project.Models.DTO;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService customerService;
        private readonly IMapper mapper;


        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;

        }
        [HttpPost("/Customer/Add")]
        public async Task<Customer> Add(CustomerDto customer)
        {
            var c = mapper.Map<Customer>(customer);

            await customerService.Add(c);

            return c;
        }
        [HttpGet("/Customer/GetAllCustomers")]
        public async Task<List<Customer>> GetAllCustomer()
        {
            return await customerService.GetAllCustomer();


        }
        [HttpDelete("/Customer/{deleteCustomer}")]
        public async Task<bool> DeleteCustomer(int customerId)
        {
            return await customerService.DeleteCustomer(customerId);
        }
        [HttpPut("/Customer/{UpdateCustomer}")]
        public async Task<Customer> UpdateCustomer(CustomerDto newCustomer, int customerId)
        {
            return await customerService.UpdateCustomer(newCustomer, customerId);
        }
        [HttpGet("/Customer/{FindCustomerByName}")]
        public async Task<Customer> FindCustomerByName(string name)
        {
            return await customerService.FindCustomerByName(name);
        }
        [HttpGet("/Customer/{FindCustomerById}")]
        public async Task<Customer> FindCustomerById(int Id)
        {
            return await customerService.FindCustomerById(Id);
        }
    }
}

