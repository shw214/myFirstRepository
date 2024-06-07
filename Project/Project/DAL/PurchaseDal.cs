using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project.Models;

namespace Project.DAL
{
    public class PurchaseDal : IPurchaseDal
    {
        private readonly OrdersContext ordersContext;

        public PurchaseDal(OrdersContext ordersContext)
        {
            this.ordersContext = ordersContext;
        }
        public async Task<Purchase> Add(Purchase purchase)
        {
            try
            {
                await ordersContext.Purchase.AddAsync(purchase);
                await ordersContext.SaveChangesAsync();
                return purchase;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Purchase>> GetAllPurchases()
        {
            try
            {
                List<Purchase> purchases = await ordersContext.Purchase.ToListAsync();
                return purchases;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<List<Purchase>> GetPresentPurchase(int presentId)
        {
            try
            {
                List<Purchase> purchase = await ordersContext.Purchase.Where(p => p.PresentId == presentId).ToListAsync();

                return purchase;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting Present");
            }
        }

        public async Task<bool> DeletePurchase(int purchaseId)
        {
            try
            {
                List<Purchase> purchases = await ordersContext.Purchase.ToListAsync();
                Purchase deletePurchase = purchases.FirstOrDefault(p => p.Id == purchaseId);
                if (deletePurchase == null)
                {

                    return false;
                }
                else
                {
                    ordersContext.Purchase.Remove(deletePurchase);
                    await ordersContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Purchase> UpdatePurchase(Purchase newPurchase, int purchaseId)
        {
            try
            {
                Purchase purchaseToUpdate = await ordersContext.Purchase.FirstOrDefaultAsync(p => p.Id == purchaseId);
                if (purchaseToUpdate == null)
                {
                    return null;
                }
                else
                {
                    purchaseToUpdate.Id = newPurchase.Id;
                    purchaseToUpdate.PresentId = newPurchase.PresentId;
                    purchaseToUpdate.Presents = newPurchase.Presents;
                    purchaseToUpdate.Customer = newPurchase.Customer;
                    ordersContext.Purchase.Update(purchaseToUpdate);
                    await ordersContext.SaveChangesAsync();
                    return purchaseToUpdate;
                }
            }
        
            catch (Exception ex)
            {
                throw new Exception("UpdatePresent failed");
            }
        }
        public async Task<Purchase> FindPurchaseById(int Id)
        {
            try
            {
                List<Purchase> purchases = await ordersContext.Purchase.ToListAsync();
                Purchase purchase = purchases.FirstOrDefault(p => p.Id == Id);
                if (purchase == null)
                {
                    return null;
                }
                return purchase;
            }
            catch (Exception ex)
            {
                throw new Exception("FindPurchaseById failed");
            }
        }

        public async Task<Customer> GetCustomerDetails(int purchaseId)
        {
            try
            {
                List<Purchase> purchases = await ordersContext.Purchase.ToListAsync();
                Purchase purchase = purchases.FirstOrDefault(p => p.Id == purchaseId);
                return purchase.Customer;
            }
            catch (Exception ex)
            {
                throw new Exception("GetCustomerDetails failed");
            }
        }
        public async Task<List<Customer>> GetAllCustomersDetails()
        {
            try
            {
                List<Customer> customers =  await ordersContext.Customer.Where(p => p.Present.IsNullOrEmpty()).ToListAsync();
                return customers;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllCustomersDetails failed");
            }
        }


    }
}

