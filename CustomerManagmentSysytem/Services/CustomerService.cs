using CustomerManagmentSysytem.Data;
using CustomerManagmentSysytem.Data.Mdoels;
using CustomerManagmentSysytem.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagmentSysytem.Services
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomerService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Customers>> GetAllCustomer()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public Customers GetCustomerById(int id)
        {
            return _dbContext.Customers.Find(id);
        }

        public Customers AddCustomer(Customers customer)
        {
            _dbContext.Customers.Add(new Customers() {
                CustomerEmail = customer.CustomerEmail,
                CustomerPassword = customer.CustomerPassword,
                CustomerFullName = customer.CustomerFullName,
                OwnerId = customer.OwnerId,
                owners = _dbContext.Owners.Find(Convert.ToInt32(customer.OwnerId))
            });
            _dbContext.SaveChanges();
            return customer;
        }

        public Customers getCustomerByEmail(string  customerMail)
        {
           
            var customer = _dbContext.Customers.Where(e => e.CustomerEmail == customerMail).FirstOrDefault();
            
            return customer;
        }

        public async Task<bool> saveFileInDb(IFormFile file, int id,string fileName)
        {
            var customer = _dbContext.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            if (!(customer is null))
            {
                

                using (var memoryStream =new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);

                    customer.FileData = memoryStream.ToArray();
                    customer.FileName = fileName;
                    customer.FileSize = memoryStream.ToArray().Length;
                    customer.TimeOfUpload = DateTime.Now.Date;

                    customer.BaseImage64 = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(memoryStream.ToArray(),0, memoryStream.ToArray().Length));
                    _dbContext.Customers.Update(customer);
                }
                    try
                    {
                       await _dbContext.SaveChangesAsync();
                        return true;
                    }
                    catch (DbUpdateException e)
                    {
                        throw e;
                    }
              
            }
           
            else
            {
                return false;
            }
               
        }



        public async Task<Customers> UpdateCustomer(int id,Customers customer)
        {
          
            var CustomerFound = _dbContext.Customers.Find(id);

            if (!(CustomerFound is null))
            {

                CustomerFound.CustomerEmail = !(customer.CustomerEmail is null)?customer.CustomerEmail:CustomerFound.CustomerEmail ;
                CustomerFound.CustomerFullName = !(customer.CustomerFullName is null) ? customer.CustomerFullName : CustomerFound.CustomerFullName;
                CustomerFound.CustomerPassword = !(customer.CustomerPassword is null) ? customer.CustomerPassword : CustomerFound.CustomerPassword;

                _dbContext.Customers.Update(CustomerFound);

                try
                {
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!CustomersExists(id))
                    {
                        throw new UnwantedBehaviourException($"Customer with id={id} cannot be updated");
                    }
                    else
                    {
                        throw ex;
                    }
                }
                
                return customer;
            }
            return null;
        }

        public Customers DeleteCustomer(int id) {

            var CustomerFound = _dbContext.Customers.Where(d => d.CustomerId == id).FirstOrDefault();
            if (!(CustomerFound is null))
            {
                _dbContext.Customers.Remove(CustomerFound);
                _dbContext.SaveChanges();
            }

            return CustomerFound;
        }

        public bool CustomersExists(int id)
        {
            return _dbContext.Customers.Any(e => e.CustomerId == id);
        }
    }

}
