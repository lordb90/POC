namespace ThrowAway005.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DASHBOARD.Delivery")]
    public partial class Delivery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Delivery()
        {
            HospitalDeliveries = new HashSet<HospitalDelivery>();
        }

        public int DeliveryID { get; set; }

        public long ReportingQuarterID { get; set; }

        [StringLength(120)]
        public string CqsSource { get; set; }

        [StringLength(120)]
        public string VbpSource { get; set; }

        [StringLength(120)]
        public string UtilizationSource { get; set; }

        public long? CqsReportingQuarterIDBegin { get; set; }

        public long? CqsReportingQuarterIDEnd { get; set; }

        public long? VpbReportingQuarterIDBegin { get; set; }

        public long? VbpReportingQuarterIDEnd { get; set; }

        public long? UtilizationReportingQuarterIDBegin { get; set; }

        public long? UtilizationReportingQuarterIDEnd { get; set; }

        [StringLength(120)]
        public string Domain1Name { get; set; }

        [StringLength(120)]
        public string Domain2Name { get; set; }

        [StringLength(120)]
        public string Domain3Name { get; set; }

        [StringLength(120)]
        public string Domain4Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HospitalDelivery> HospitalDeliveries { get; set; }
    }
}
