namespace ThrowAway005.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DashboardContext : DbContext
    {
        public DashboardContext()
            : base("name=DashboardContext")
        {
        }

        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<HospitalDelivery> HospitalDeliveries { get; set; }
        public virtual DbSet<Utilization> Utilizations { get; set; }
        public virtual DbSet<Visualization> Visualizations { get; set; }

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

            modelBuilder.Entity<Delivery>()
                .Property(e => e.Domain1Name)
                .IsUnicode(false);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.Domain2Name)
                .IsUnicode(false);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.Domain3Name)
                .IsUnicode(false);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.Domain4Name)
                .IsUnicode(false);

            modelBuilder.Entity<Delivery>()
                .HasMany(e => e.HospitalDeliveries)
                .WithRequired(e => e.Delivery)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.CCN)
                .IsUnicode(false);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.HospitalName)
                .IsUnicode(false);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.HospitalCity)
                .IsUnicode(false);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.HospitalState)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.CqsNationalPercentile)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.RamiNationalPercentile)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.RaciNationalPercentile)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.RariNationalPercentile)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.PsiNationalPercentile)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.IqiNationalPercentile)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpDomain1Score)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpDomain2Score)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpDomain3Score)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpDomain4Score)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpTotalPerformanceScore)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpDomain1Percentile)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpDomain2Percentile)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpDomain3Percentile)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpDomain4Percentile)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpTotalPerformancePercentile)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpIncentivePaymentPercentage)
                .HasPrecision(9, 8);

            modelBuilder.Entity<HospitalDelivery>()
                .HasMany(e => e.Utilizations)
                .WithRequired(e => e.HospitalDelivery)
                .HasForeignKey(e => new { e.DeliveryID, e.HospitalID })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utilization>()
                .Property(e => e.ActualCost)
                .HasPrecision(9, 0);

            modelBuilder.Entity<Utilization>()
                .Property(e => e.ActualLos)
                .HasPrecision(6, 1);

            modelBuilder.Entity<Utilization>()
                .Property(e => e.ComparitiveCost)
                .HasPrecision(9, 0);

            modelBuilder.Entity<Utilization>()
                .Property(e => e.ComparitiveLos)
                .HasPrecision(6, 1);

            modelBuilder.Entity<Visualization>()
                .Property(e => e.CCN)
                .IsUnicode(false);

            modelBuilder.Entity<Visualization>()
                .Property(e => e.BlobWebAddress)
                .IsUnicode(false);
        }
    }
}
