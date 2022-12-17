using CustomerManagmentSysytem.Data;
using CustomerManagmentSysytem.Data.Mdoels;
using CustomerManagmentSysytem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagmentSysytem.Services
{
    public class DependencyService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly CustomerService _customerService;


        public DependencyService(CustomerService customerService,ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _customerService = customerService;
        }


        public Customer_Service RegisterDependency(Customer_Service customer_Service) {
            customer_Service.isActive = true;
            _dbContext.Customer_Service.Add(customer_Service);
            _dbContext.SaveChanges();
            return customer_Service;
        }

    public IEnumerable<Customer_Service> GetAllDependencies()
    {

            return _dbContext.Customer_Service.ToList();
            //List<int> CustomerId = null;
            //List<int> ServiceId = null;

            //var result = _dbContext.Customer_Service.Select(d => new Customer_Service()
            //{
            //    CustomerId = d.CustomerId

            //}).ToList();

            //var r=result.Count;
            //List<Customers> customers = new List<Customers>();
            //foreach (var id in result) {

            //    customers.Add(await _dbContext.Customers.FindAsync(id.CustomerId));
            //}

            //int a = customers.Count;

            //ServiceId = _dbContext.Customer_Service.Select(d => d.ServiceId).ToList();


            //return CustomerId;
    }



    public Customer_Service GetDependencyById(int id)
    {
        return _dbContext.Customer_Service.Find(id);
    }

    public Customer_Service GetDependencyByUnique(int CustomerId,int ServiceId)
        {
            return _dbContext.Customer_Service.Where(d => d.CustomerId == CustomerId && d.ServiceId == ServiceId).FirstOrDefault();
        }

    //public void AddNewDependency(Customer_Service customer_Service)
    //{
    //    _dbContext.Customer_Service.Add(customer_Service);            
    //    _dbContext.SaveChanges();
    //}

    public Customer_Service UpdateDependency(Customer_Service customer_Service)
    {

        var DependencyToUpdate = _dbContext.Customer_Service.Where(d=>d.CustomerId==customer_Service.CustomerId && d.ServiceId==customer_Service.ServiceId).FirstOrDefault();

        if (!(DependencyToUpdate is null))
        {
                DependencyToUpdate.isActive = customer_Service.isActive;

            _dbContext.Update(DependencyToUpdate);
            _dbContext.SaveChanges();
                
        }

        return DependencyToUpdate;
    }

    public Customer_Service DeleteDependency(int id)
    {

        var DependencyFound = _dbContext.Customer_Service.Find(id);
        if (!(DependencyFound is null))
        {
                changeServiceDb(DependencyFound);
        }

        return DependencyFound;
    }



        public Customer_Service DeleteDependencyByCustomerId(int id)
        {

            var DependencyFound = _dbContext.Customer_Service.Where(d=>d.CustomerId==id).FirstOrDefault();
            if (!(DependencyFound is null))
            {
                changeServiceDb(DependencyFound);
            }

            return DependencyFound;
        }

        public Customer_Service DeleteDependencyByService(int id)
        {

            var DependencyFound = _dbContext.Customer_Service.Where(d=>d.ServiceId==id).FirstOrDefault();
            if (!(DependencyFound is null))
            {
                changeServiceDb(DependencyFound);
            }

            return DependencyFound;
        }



        private void changeServiceDb(Customer_Service customer_Service) {
            _dbContext.Customer_Service.Remove(customer_Service);
            _dbContext.SaveChanges();
        }

        public bool DependencyExists(int id)
    {
        return _dbContext.Customer_Service.Any(e => e.Id== id);
    }


}
}
