using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Anserem_Task.Models
{
    public class SellingViewModel
    {
        public int SellingId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string SellingContact { get; set; }
        public string ContractorName { get; set; }
        public string ContractorContactPerson { get; set; }
        public string ContractorCity { get; set; }


    }
}