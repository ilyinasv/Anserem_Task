namespace Anserem_Task.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contractor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contractor()
        {
            Sellings = new HashSet<Selling>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string ContactPerson { get; set; }

        public int? CityId { get; set; }

        public string Name { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Selling> Sellings { get; set; }
    }
}
