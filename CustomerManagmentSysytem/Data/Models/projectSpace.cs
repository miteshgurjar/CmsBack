using CustomerManagmentSysytem.Data.Mdoels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagmentSysytem.Data.Models
{
    public class projectSpace
    {
        [Key]
       public int  Id { get; set; }
        //[ForeignKey]
        //public string NameId { get; set; }
        //public ServiceTypes serviceTypes { get; set; }
       public int Level { get; set; } = 0;
       public string Stage { get; set; }
       [Required]
       public  string BackendType { get; set; }
       [Required]
       public  string FrontendType { get; set; }
       [Required]
       public  DateTime StartDate { get; set; }
       [Required]
       public  DateTime EndDate { get; set; }
       [ForeignKey("customers")]
       public int CustomerID { get; set; }

       public virtual Customers customers { get; set; }
       public  List<Customers> AllocatorCustomer { get; set; }
       public List<Customers> RegisterCustomer { get; set; }

       public string typeOfUsage { get; set; }
        [NotMapped]
       public List<int> allocationId { get; set; }


    }
}
