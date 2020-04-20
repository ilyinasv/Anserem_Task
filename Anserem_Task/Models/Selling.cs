namespace Anserem_Task.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Selling
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? ContractorId { get; set; }

        public int? SellingContactId { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual Contractor Contractor { get; set; }

        public virtual SellingContact SellingContact { get; set; }
    }
}
