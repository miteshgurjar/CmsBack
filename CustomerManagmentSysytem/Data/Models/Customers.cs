using CustomerManagmentSysytem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagmentSysytem.Data.Mdoels
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
       

        public Byte[] token { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "please enter a valid name")]
        public string CustomerFullName { get; set; }
        [Required]
        [RegularExpression(pattern: "^[a-z A-Z 0-9._-]+@[a-z A-Z 0-9._-]+$", ErrorMessage = "please enter a valid email")]
        public string CustomerEmail { get; set; }

        public string CustomerPassword { get; set; }
        [ForeignKey("owners")]
        public int OwnerId { get; set; }
        public string TypeOfCustomer { get; set; } 
        public Owners owners { get; set; }


        public Byte[] FileData { get; set; }

        public string FileName{ get; set; }

        public DateTime TimeOfUpload { get; set; }
        public int FileSize { get; set; }

        public string BaseImage64 { get; set; }
        public List<Customer_Service> Customer_Service { get; set; }
    }
}
