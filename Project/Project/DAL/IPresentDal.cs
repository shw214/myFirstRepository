using Project.Models;
using Project.Models.DTO;

namespace Project.DAL
{
    public interface IPresentDal
    {
        public Task<Present> Add(Present present);
        public Task<Donor> GetPresentDonor(int presentId);
        public Task<List<Present>> GetAllPresent();
        public Task<bool> DeletePresent(int presentId);
        public Task<Present> UpdatePresent(Present newPresent, int presentId);
        public Task<Present> FindPresentByName(string name);
        public Task<Present> FindPresentByDonor(int donorId);
        public Task<Present> FindPresentByNumCustomer(int Amount);


    }
}
