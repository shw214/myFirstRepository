using Microsoft.AspNetCore.Mvc;
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
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService purchaseService;
        private readonly IMapper mapper;


        public PurchaseController(IPurchaseService getpurchaseService, IMapper mapper)
        {
            purchaseService = getpurchaseService;
            mapper = mapper;

        }
        [HttpPost("/Purchase/Add")]
        public async Task<Purchase> Add(Purchase purchase)
        {
            var c = mapper.Map<Purchase>(purchase);

            return await purchaseService.Add(c);
        }

        [HttpGet("/Purchase/GetAllPurchases")]
        public async Task<List<Purchase>> GetAllPurchases()
        {
            return await purchaseService.GetAllPurchases();
        }

        [HttpDelete("/Purchase/{DeletePurchase}")]
        public async Task<bool> DeletePurchase(int purchaseId)
        {
            return await purchaseService.DeletePurchase(purchaseId);
        }
        [HttpGet("/Purchase/{FindPurchaseById}")]
        public async Task<Purchase> FindPurchaseById(int Id)
        {
            return await purchaseService.FindPurchaseById(Id);
        }
        [HttpGet("/Purchase/{GetCustomerDetails}")]
        public async Task<Customer> GetCustomerDetails(int purchaseId)
        {
            return await purchaseService.GetCustomerDetails(purchaseId);
        }

        [HttpGet("/Purchase/GetAllCustomersDetails")]
        public async Task<List<Customer>> GetAllCustomersDetails()
        {
            return await purchaseService.GetAllCustomersDetails();
        }
        [HttpPut("/Purchase/{UpdatePurchase}")]
        public async Task<Purchase> UpdatePurchase(Purchase newPurchase, int purchaseId)
        {
            return await purchaseService.UpdatePurchase( newPurchase,  purchaseId);
        }
    }
}
