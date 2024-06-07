using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.DTO;
using System.Drawing;
using System.Linq;

namespace Project.DAL
{
    public class PresentDal : IPresentDal
    {
        private readonly OrdersContext ordersContext;

        public PresentDal(OrdersContext ordersContext)
        {
            this.ordersContext = ordersContext;
        }
        public async Task<Present> Add(Present present)
        {
            try
            {
                await ordersContext.Present.AddAsync(present);
                await ordersContext.SaveChangesAsync();
                return present;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Donor> GetPresentDonor(int presentId)
        {
            try
            {
                Present present = await ordersContext.Present.FirstOrDefaultAsync(p => p.Id == presentId);

                return present.Donor;

            }
            catch (Exception ex)
            {
                throw new Exception("Error Get Present Donor");
            }
        }


        public async Task<List<Present>> GetAllPresent()
        {
            try
            {
                List<Present> presents = await ordersContext.Present.Include(c=>c.Category).Include(c => c.Donor).ToListAsync();
                return presents;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<bool> DeletePresent(int presentId)
        {
            try
            {
                List<Present> presents = await ordersContext.Present.ToListAsync();
                Present deletePresent = presents.FirstOrDefault(p => p.Id == presentId);
                if (deletePresent == null)
                {
                    return false;
                }
                else
                {
                    ordersContext.Present.Remove(deletePresent);
                    await ordersContext.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Present> UpdatePresent(Present newPresent, int presentId)
        {
            try
            {
                Present presentToUpdate = await ordersContext.Present.FirstOrDefaultAsync(p => p.Id == presentId);
                if (presentToUpdate == null)
                {
                    return null;
                }
                else
                {
                    presentToUpdate.Name=newPresent.Name;
                    presentToUpdate.Amount=newPresent.Amount;
                    presentToUpdate.Category=newPresent.Category;
                    newPresent.Id = presentId;
                    ordersContext.Present.Update(presentToUpdate);
                    await ordersContext.SaveChangesAsync();
                    return presentToUpdate;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("UpdatePresent failed");
            }
        }


        public async Task<Present> FindPresentByName(string name)
        {
            try
            {
                List<Present> presents = await ordersContext.Present.ToListAsync();
                Present Present =  presents.FirstOrDefault(p => p.Name == name);
                if (Present == null)
                {
                    return null;
                }
                return Present;
            }
            catch (Exception ex)
            {
                throw new Exception("FindPresentByName failed");
            }
        }
        public async Task<Present> FindPresentByDonor(int donorId)
        {
            try
            {
                List<Present> presents = await ordersContext.Present.ToListAsync();
                Present Present = presents.FirstOrDefault(p => p.DonorId == donorId);
                if (Present == null)
                {
                    return null;
                }
                return Present;
            }
            catch (Exception ex)
            {
                throw new Exception("FindPresentByDonor failed");
            }

        }
        public async Task<Present> FindPresentByNumCustomer(int Amount)//?Amount== מס' רוכשים
        {
            try
            {
                List<Present> presents = await ordersContext.Present.ToListAsync();
                Present Present = presents.FirstOrDefault(p => p.CustomerAcount == Amount);
                if (Present != null)
                {
                    return Present;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("FindPresentByNumCustomer failed");
            }
        }
    }
}
