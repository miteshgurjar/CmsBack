using CustomerManagmentSysytem.Data;
using CustomerManagmentSysytem.Data.Mdoels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagmentSysytem.Services
{
    public class OwnerService
    {
        private readonly ApplicationDbContext _dbContext;


        public OwnerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  IEnumerable<Owners> GetAllOwners()
        {
            return  _dbContext.Owners.ToList();
        }

        public Owners GetOwnerById(int id)
        {
            return _dbContext.Owners.Find(id);
        }


        public void AddNewOwner(Owners owners)
        {
            _dbContext.Owners.Add(owners);
            _dbContext.SaveChanges();
        }

        public Owners UpdateOwnerDetails(int id,Owners owner)
        {


            var OwnerToUpdate = _dbContext.Owners.Find(id);

            if(!(OwnerToUpdate is null))
            {
                OwnerToUpdate.OwnerEmail = (owner.OwnerEmail is "def") ? OwnerToUpdate.OwnerEmail: owner.OwnerEmail;
                OwnerToUpdate.OwnerFullName = (owner.OwnerFullName is "def") ?  OwnerToUpdate.OwnerFullName : owner.OwnerFullName;
                OwnerToUpdate.OwnerPassword = (owner.OwnerPassword is "def") ?  OwnerToUpdate.OwnerPassword : owner.OwnerPassword;

                _dbContext.Update(OwnerToUpdate);
                try
                {
                    _dbContext.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }


            }

            return null;
        }

        public async Task<Owners> DeleteOwner(int id)
        {

            var OwnerFound = _dbContext.Owners.Where(d=> d.OwnerId == id).First();

            if ((OwnerFound != null))
            {
                _dbContext.Owners.Remove(OwnerFound);
                try
                {
                    await _dbContext.SaveChangesAsync();
                    return OwnerFound;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        }

        public bool OwnerExists(int id)
        {
            return _dbContext.Owners.Any(e => e.OwnerId== id);
        }


    }
}
