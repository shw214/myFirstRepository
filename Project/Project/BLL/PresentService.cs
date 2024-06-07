﻿using Project.DAL;
using Project.Models;
using Project.Models.DTO;

namespace Project.BLL
{
    public class PresentService : IPresentService
    {
        private readonly IPresentDal presentDal;
        public PresentService(IPresentDal presentDal)
        {
            this.presentDal = presentDal;
        }
        public async Task<Present> Add(Present present)
        {
            return await presentDal.Add(present);
        }
        public async Task<Donor> GetPresentDonor(int presentId)
        {
            return await presentDal.GetPresentDonor(presentId);

        }
        public async Task<List<Present>> GetAllPresent()
        {
            return await presentDal.GetAllPresent();

        }
        public async Task<bool> DeletePresent(int presentId)
        {
            return await presentDal.DeletePresent(presentId);
        }
        public async Task<Present> UpdatePresent(Present newPresent, int presentId)
        {
            return await presentDal.UpdatePresent(newPresent, presentId);
        }
        public async Task<Present> FindPresentByName(string name)
        {
            return await presentDal.FindPresentByName(name);
        }
        public async Task<Present> FindPresentByDonor(int donorId)
        {
            return await presentDal.FindPresentByDonor(donorId);
        }
        public async Task<Present> FindPresentByNumCustomer(int Amount)
        {
            return await presentDal.FindPresentByNumCustomer(Amount);
        }
    }
}
