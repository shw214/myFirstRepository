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
    public class DonorController : ControllerBase
    {


        private readonly IDonorService donorService;
        private readonly IMapper mapper;
        //DonorService donorService;

        public DonorController(IDonorService idonorService, IMapper mapper)
        {
            this.donorService = idonorService;
            this.mapper = mapper;

        }
        [HttpPost("/Donor/Add")]
        public async Task<Donor> Add(DonorDto donor)
        {
            var p = mapper.Map<Donor>(donor);
            await donorService.Add(p);
            //להוסיף גם לטבלת המתנות
            return p;
        }
        [HttpGet("/Donor/GetAllDonors")]
        public async Task<List<Donor>> GetAllDonor()
        {
            return await donorService.GetAllDonor();

        }
        [HttpGet("/Donor/{GetPresentByDonor}")]
        public async Task<List<Present>> GetPresentByDonor(int donorId)
        {
            return await donorService.GetPresentByDonor(donorId);
        }
        [HttpGet("/Donor/{GetDonorByMail}")]
        public async Task<Donor> GetDonorByMail(string Mail)
        {
            return await donorService.GetDonorByMail(Mail);
        }
        [HttpGet("/Donor/{GetDonorByName}")]
        public async Task<Donor> GetDonorByName(string Name)
        {
            return await donorService.GetDonorByMail(Name);
        }
        [HttpPut("/Donor/{UpdateDonor}")]
        public async Task<Donor> UpdateDonor(DonorDto donor, int id)
        {

            return await donorService.UpdateDonor(donor, id);
        }
    }
}

