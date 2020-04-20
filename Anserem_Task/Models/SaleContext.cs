namespace Anserem_Task.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SaleContext : DbContext
    {
        public SaleContext()
            : base("name=SellingModel")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Contractor> Contractors { get; set; }
        public virtual DbSet<SellingContact> SellingContacts { get; set; }
        public virtual DbSet<Selling> Sellings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
