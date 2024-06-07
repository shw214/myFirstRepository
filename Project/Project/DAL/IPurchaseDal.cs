using Project.Models;

namespace Project.DAL
{
    public interface IPurchaseDal
    {
        public Task<Purchase> Add(Purchase purchase);

        public Task<List<Purchase>> GetAllPurchases();
        public Task<bool> DeletePurchase(int purchaseId);
        public Task<Purchase> FindPurchaseById(int Id);
        public Task<Customer> GetCustomerDetails(int purchaseId);
        public Task<List<Customer>> GetAllCustomersDetails();
        public Task<Purchase> UpdatePurchase(Purchase newPurchase, int purchaseId);

    }
}
