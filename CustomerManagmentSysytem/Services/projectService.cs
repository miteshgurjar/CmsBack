using CustomerManagmentSysytem.Data;
using CustomerManagmentSysytem.Data.Mdoels;
using CustomerManagmentSysytem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagmentSysytem.Services
{
    public class projectService
    {
        private readonly ApplicationDbContext _dbContext;
        
        public projectService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
           
        }


        public bool assignLevel(Customers customer, int level) {

            _dbContext.projectSpaces.Add (new projectSpace { CustomerID = customer.CustomerId,
                Level = level
            });

            try
            {
                _dbContext.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (DbUpdateException ex)
            { 
                throw ex;
            }

            return true;
           
        }





    }
}
