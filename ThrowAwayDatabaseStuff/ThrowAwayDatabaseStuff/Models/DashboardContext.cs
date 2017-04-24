namespace ThrowAwayDatabaseStuff.Models
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
                .Property(e => e.VbpClinicalCareScore)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpExperienceScore)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpSafetyScore)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpEfficiencyScore)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpTotalPerformanceScore)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpClinicalCarePercentile)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpExperiencePercentile)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpSafetyPercentile)
                .HasPrecision(9, 6);

            modelBuilder.Entity<HospitalDelivery>()
                .Property(e => e.VbpEfficiencyPercentile)
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
        }
    }
}
