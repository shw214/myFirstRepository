using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.DTO;

namespace Project.DAL
{
    public class CustomerDal : ICustomerDal
    {
        private readonly OrdersContext ordersContext;

        public CustomerDal(OrdersContext ordersContext)
        {
            this.ordersContext = ordersContext;
        }
        public async Task<Customer> Add(Customer customer)
        {
            try
            {
                await ordersContext.Customer.AddAsync(customer);
                await ordersContext.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Customer>> GetAllCustomer()
        {
            try
            {
                return await ordersContext.Customer.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<bool> DeleteCustomer(int customerId)
        {
            try
            {
                List<Customer> customers = await ordersContext.Customer.ToListAsync();
                Customer deleteCustomer = customers.FirstOrDefault(p => p.Id == customerId);
                if (deleteCustomer == null)
                {
                    return false;
                }
                else
                {
                    ordersContext.Customer.Remove(deleteCustomer);
                    await ordersContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Customer> UpdateCustomer(CustomerDto newCustomer, int customerId)
        {
            try
            {
        Customer customerToUpdate = await ordersContext.Customer.FirstOrDefaultAsync(p => p.Id == customerId);
                if (customerToUpdate == null)
                {
                    return null;
                }
                else
                {
                    customerToUpdate.FirstName=newCustomer.FirstName;
            customerToUpdate.Mail=newCustomer.Mail;
             customerToUpdate.Password=newCustomer.Password;

                    customerToUpdate.Phone=newCustomer.Phone;
                    ordersContext.Customer.Update(customerToUpdate);
                    await ordersContext.SaveChangesAsync();
                    return customerToUpdate;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Update Present failed");
            }
        }


        public async Task<Customer> FindCustomerByName(string name)
        {
            try
            {
                List<Customer> customers = await ordersContext.Customer.ToListAsync();
                Customer customer = customers.FirstOrDefault(p => p.FirstName == name);
                if (customer == null)
                {
                    return null;
                }
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("FindPresentByName failed");
            }
        }
        public async Task<Customer> FindCustomerById(int Id)
        {
            try
            {
                List<Customer> customers = await ordersContext.Customer.ToListAsync();
                Customer customer = customers.FirstOrDefault(p => p.Id == Id);
                if (customer == null)
                {
                    return null;
                }
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("FindPresentByName failed");
            }
        }
    }
}
