using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagmentSysytem.Data.Models
{
    public class Analytical
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime dateOfUpload { get; set; }

        public byte[] Images { get; set; }


    }
}
