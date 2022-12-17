using CustomerManagmentSysytem.Data.Mdoels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagmentSysytem.Data.Models
{
    public class Resolution
    {
        [Key]
        public int ResolutionId { get; set; }

        public string PhaseOfResolution { get; set; }

        [ForeignKey("customerId")]
        public int CustomerId { get; set; }

        public virtual Customers Customer { get; set; }

        [ForeignKey("ownerId")]
        public int OwnerId {get;set;}

        public virtual Owners Owners { get; set; }

    }
}
