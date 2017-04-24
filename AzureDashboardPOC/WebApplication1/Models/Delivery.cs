namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DASHBOARD.Delivery")]
    public partial class Delivery
    {
        public int DeliveryID { get; set; }

        public long ReportingQuarterID { get; set; }

        [StringLength(120)]
        public string CqsSource { get; set; }

        [StringLength(120)]
        public string VbpSource { get; set; }

        [StringLength(120)]
        public string UtilizationSource { get; set; }
    }
}
