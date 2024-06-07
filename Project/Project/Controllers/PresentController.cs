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

    public class PresentController : ControllerBase
    {

        private readonly IPresentService presentService;
        private readonly IMapper mapper;


        public PresentController(IPresentService presentService, IMapper mapper)
        {
            this.presentService = presentService;
            this.mapper = mapper;

        }
        [HttpPost("/Present/Add")]
        public async Task<Present> Add(PresentDto Present)
        {
            var c = mapper.Map<Present>(Present);
            
            return await presentService.Add(c);
        }
        [HttpGet("/Present/GetAllPresents")]
        public async Task<List<Present>> GetAllPresent()
        {

            return await presentService.GetAllPresent();
        }
        [HttpDelete("/Present/{presentId}")]
        public async Task<bool> DeletePresent(int presentId)
        {
            return await presentService.DeletePresent(presentId);
        }
        [HttpPut("/Present/{UpdatePresent}")]
        public async Task<Present> UpdatePresent(Present newPresent, int presentId)
        {
            return await presentService.UpdatePresent(newPresent, presentId);
        }
        [HttpGet("/Present/{FindPresentByName}")]
        public async Task<Present> FindPresentByName(string name)
        {
            return await presentService.FindPresentByName(name);
        }
        [HttpGet("/Present/{FindPresentByDonor}")]
        public async Task<Present> FindPresentByDonor(int donorId)
        {
            return await presentService.FindPresentByDonor(donorId);

        }
        [HttpGet("/Present/{FindPresentByNumCustomer}")]

        public async Task<Present> FindPresentByNumCustomer(int Amount)
        {
            return await presentService.FindPresentByNumCustomer(Amount);
        }
    }
}

