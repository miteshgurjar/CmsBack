using CustomerManagmentSysytem.Data.Mdoels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagmentSysytem.Data.Models
{
    public class ServiceTypes
    {
        [Key]
        public int ServiceId { get; set; }
        [Required]
        
        public string ServiceName { get; set; }

        
        [ForeignKey("Owners")]
        public int OwnerId { get; set; }

        public Owners Owners { get; set; }
        public List<Customer_Service> Customer_Service { get; set; }

        public override string ToString()
        {
            return new string("serviceId :" +ServiceId +"serviceName: "+ ServiceName);
        }

    }
}
