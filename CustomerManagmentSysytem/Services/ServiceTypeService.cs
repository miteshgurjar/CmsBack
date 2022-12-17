using CustomerManagmentSysytem.Data;
using CustomerManagmentSysytem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagmentSysytem.Services
{
    public class ServiceTypeService
    {
        private readonly ApplicationDbContext _dbContext;
        public ServiceTypeService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<ServiceTypes> GetAllServices()
        {
            return _dbContext.ServiceTypes.ToList();
        }

        public Task<ServiceTypes> GetServiceById(int id)
        {
            return _dbContext.ServiceTypes.FindAsync(id);
        }

        public  void AddService(ServiceTypes serviceType)
        {

            try
            {
                _dbContext.ServiceTypes.Add(serviceType);
                 _dbContext.SaveChanges();
            }
            catch( Exception ex) {
                throw ex;
            }
        }

        public IEnumerable<ServiceTypes> getServiceByCustomerId(int id)
        {
            List<ServiceTypes> serviceDetails = _dbContext.ServiceTypes.Where( e=> e.OwnerId ==id ).ToList();
            return serviceDetails;
            
        }

        public ServiceTypes UpdateService(int id, ServiceTypes serviceTypes)
        {

            var ServiceFound = _dbContext.ServiceTypes.Find(id);

            if (!(ServiceFound is null))
            {

                ServiceFound.ServiceName = !(serviceTypes.ServiceName is " ") ? serviceTypes.ServiceName : ServiceFound.ServiceName;
                
                _dbContext.ServiceTypes.Update(ServiceFound);
                _dbContext.SaveChanges();
                return ServiceFound;
            }
            return null;
        }

        public ServiceTypes DeleteService(int id)
        {

            var ServiceFound = _dbContext.ServiceTypes.Where(d=>d.ServiceId==id).FirstOrDefault();
            if (!(ServiceFound is null))
            {
               var d= ServiceFound.ServiceId;
                _dbContext.ServiceTypes.Remove(ServiceFound);
                _dbContext.SaveChanges();
            }

            return ServiceFound;
        }

        public bool ServiceTypeExists(int id)
        {
            return _dbContext.ServiceTypes.Any(e => e.ServiceId == id);
        }
    }
}
