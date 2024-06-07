using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.DTO;
using System.Linq;

namespace Project.DAL
{
    public class DonorDal : IDonorDal
    {
        private readonly OrdersContext ordersContext;

        public DonorDal(OrdersContext ordersContext)
        {
            this.ordersContext = ordersContext;
        }
        public async Task<Donor> Add(Donor donor)
        {
            try
            {
                await ordersContext.Donor.AddAsync(donor);
                await ordersContext.SaveChangesAsync();
                return donor;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public async Task<List<Donor>> GetAllDonor()
        {
            try
            {
                return await ordersContext.Donor.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Error getting Donor");
            }
        }
        public async Task<List<Present>> GetPresentByDonor(int donorId)
        {

            try
            {

                var present = await ordersContext.Present.Where(d => d.DonorId == donorId).ToListAsync();
                return present;
            }

            catch (Exception ex)
            {
                throw new Exception("Error getting Donor");
            }
        }
        public async Task<Donor> GetDonorByMail(string Mail)
        {

            try
            {
                Donor donorByMail = await ordersContext.Donor.FirstOrDefaultAsync(d => d.Mail == Mail);

                return donorByMail;
            }

            catch (Exception ex)
            {
                throw new Exception("Error getting Donor");
            }
        }


        public async Task<Donor> GetDonorByName(string Name)
        {

            try
            {
                Donor donorByMail = await ordersContext.Donor.FirstOrDefaultAsync(d => d.LastName == Name);

                return donorByMail;
            }

            catch (Exception ex)
            {
                throw new Exception("Error getting Donor");
            }
        }
        public async Task<Donor> UpdateDonor(DonorDto donor, int id)
        {
            Donor donorToUpdate = await ordersContext.Donor.FirstOrDefaultAsync(d => d.Id == id);
            donorToUpdate.FirstName = donor.FirstName;
            donorToUpdate.LastName = donor.LastName;
            donorToUpdate.Phone = donor.Phone;
            donorToUpdate.Mail = donor.Mail;
            
            if (donorToUpdate != null)
            {
                try
                {
                    ordersContext.Update(donor);
                    await ordersContext.SaveChangesAsync();
                    return donorToUpdate;


                }
                catch (Exception ex)
                {
                    throw new Exception("Error Update Donor");
                }
            }
            return null;

        }


    }
}


