using CustomerManagmentSysytem.Data.Mdoels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagmentSysytem.Data.Models
{
    public class Customer_Service
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }

        public Customers Customers { get; set; }
        [ForeignKey("ServiceTypes")]
        public int ServiceId { get; set; }

        public ServiceTypes ServiceTypes{ get; set; }

        public bool isActive { get; set; }
    }
}
