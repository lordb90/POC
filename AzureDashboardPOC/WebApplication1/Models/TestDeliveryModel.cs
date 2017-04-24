namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TestDeliveryModel : DbContext
    {
        public TestDeliveryModel()
            : base("name=TestDeliveryModel")
        {
        }

        public virtual DbSet<Delivery> Deliveries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delivery>()
                .Property(e => e.CqsSource)
                .IsUnicode(false);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.VbpSource)
                .IsUnicode(false);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.UtilizationSource)
                .IsUnicode(false);
        }
    }
}
