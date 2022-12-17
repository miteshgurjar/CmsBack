using CustomerManagmentSysytem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagmentSysytem.Data.Mdoels
{
    public class Owners
    {
        [Key]
        public int OwnerId { get; set; }
        [Required]
        public string OwnerFullName { get; set; }
        [Required]
        
        public string OwnerEmail { get; set; }
        [Required]
        public string OwnerPassword { get; set; }

        public List<Customers> Customers { get; set; }
        public List<ServiceTypes> ServiceTypes { get; set; }


    }
}
