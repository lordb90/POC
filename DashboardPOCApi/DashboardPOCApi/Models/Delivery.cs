namespace DashboardPOCApi.Models
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HospitalDelivery> HospitalDeliveries { get; set; }
    }
}
