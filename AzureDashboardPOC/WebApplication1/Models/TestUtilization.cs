namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TestUtilization : DbContext
    {
        public TestUtilization()
            : base("name=TestUtilization")
        {
        }

        public virtual DbSet<Utilization> Utilizations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
