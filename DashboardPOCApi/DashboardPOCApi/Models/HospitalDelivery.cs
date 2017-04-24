namespace DashboardPOCApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DASHBOARD.HospitalDelivery")]
    public partial class HospitalDelivery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HospitalDelivery()
        {
            Utilizations = new HashSet<Utilization>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeliveryID { get; set; }

        [Required]
        [StringLength(10)]
        public string CCN { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long HospitalID { get; set; }

        [StringLength(120)]
        public string HospitalName { get; set; }

        [StringLength(50)]
        public string HospitalCity { get; set; }

        [StringLength(2)]
        public string HospitalState { get; set; }

        public decimal? CqsNationalPercentile { get; set; }

        public byte? CqsNationalRatingID { get; set; }

        public decimal? RamiNationalPercentile { get; set; }

        public byte? RamiNationalRatingID { get; set; }

        public decimal? RaciNationalPercentile { get; set; }

        public byte? RaciNationalRatingID { get; set; }

        public decimal? RariNationalPercentile { get; set; }

        public byte? RariNationalRatingID { get; set; }

        public decimal? PsiNationalPercentile { get; set; }

        public byte? PsiNationalRatingID { get; set; }

        public decimal? IqiNationalPercentile { get; set; }

        public byte? IqiNationalRatingID { get; set; }

        public decimal? VbpClinicalCareScore { get; set; }

        public decimal? VbpExperienceScore { get; set; }

        public decimal? VbpSafetyScore { get; set; }

        public decimal? VbpEfficiencyScore { get; set; }

        public decimal? VbpTotalPerformanceScore { get; set; }

        public decimal? VbpClinicalCarePercentile { get; set; }

        public decimal? VbpExperiencePercentile { get; set; }

        public decimal? VbpSafetyPercentile { get; set; }

        public decimal? VbpEfficiencyPercentile { get; set; }

        public decimal? VbpTotalPerformancePercentile { get; set; }

        public byte? VbpClinicalCareRatingID { get; set; }

        public byte? VbpExperienceRatingID { get; set; }

        public byte? VbpSafetyRatingID { get; set; }

        public byte? VbpEfficiencyRatingID { get; set; }

        public byte? VbpTotalPerformanceRatingID { get; set; }

        public decimal? VbpIncentivePaymentPercentage { get; set; }

        public virtual Delivery Delivery { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utilization> Utilizations { get; set; }
    }
}
