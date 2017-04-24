namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TestHospitalDelivery : DbContext
    {
        public TestHospitalDelivery()
            : base("name=TestHospitalDelivery")
        {
        }

        public virtual DbSet<HospitalDelivery> HospitalDeliveries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}
