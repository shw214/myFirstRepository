using Project.DAL;
using Project.Models;

namespace Project.BLL
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseDal purchaseDal;
        public PurchaseService(IPurchaseDal purchasedal)
        {
            this.purchaseDal = purchasedal;
        }

        public async Task<Purchase> Add(Purchase purchase)
        {

            return await purchaseDal.Add(purchase);
        }
        public async Task<List<Purchase>> GetAllPurchases()
        {
            return await purchaseDal.GetAllPurchases();
        }
        public async Task<bool> DeletePurchase(int purchaseId)
        {
            return await purchaseDal.DeletePurchase(purchaseId);
        }
        public async Task<Purchase> FindPurchaseById(int Id)
        {
            return await purchaseDal.FindPurchaseById(Id);
        }

        public async Task<Customer> GetCustomerDetails(int purchaseId)
        {
            return await purchaseDal.GetCustomerDetails(purchaseId);
        }
        public async Task<List<Customer>> GetAllCustomersDetails()
        {
            return await purchaseDal.GetAllCustomersDetails();
        }
        public async Task<Purchase> UpdatePurchase(Purchase newPurchase, int purchaseId)
        {
            return await purchaseDal.UpdatePurchase(newPurchase, purchaseId);
        }
    }
}
