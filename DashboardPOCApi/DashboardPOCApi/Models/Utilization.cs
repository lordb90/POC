namespace DashboardPOCApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DASHBOARD.Utilization")]
    public partial class Utilization
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeliveryID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long HospitalID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ReportingQuarterID { get; set; }

        public decimal? ActualCost { get; set; }

        public decimal? ActualLos { get; set; }

        public decimal? ComparitiveCost { get; set; }

        public decimal? ComparitiveLos { get; set; }

        public byte? CostRatingID { get; set; }

        public byte? LosRatingID { get; set; }

        public virtual HospitalDelivery HospitalDelivery { get; set; }
    }
}
