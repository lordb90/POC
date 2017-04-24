namespace ThrowAway005.Models
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

        public decimal? VbpDomain1Score { get; set; }

        public decimal? VbpDomain2Score { get; set; }

        public decimal? VbpDomain3Score { get; set; }

        public decimal? VbpDomain4Score { get; set; }

        public decimal? VbpTotalPerformanceScore { get; set; }

        public decimal? VbpDomain1Percentile { get; set; }

        public decimal? VbpDomain2Percentile { get; set; }

        public decimal? VbpDomain3Percentile { get; set; }

        public decimal? VbpDomain4Percentile { get; set; }

        public decimal? VbpTotalPerformancePercentile { get; set; }

        public byte? VbpDomain1RatingID { get; set; }

        public byte? VbpDomain2RatingID { get; set; }

        public byte? VbpDomain3RatingID { get; set; }

        public byte? VbpDomain4RatingID { get; set; }

        public byte? VbpTotalPerformanceRatingID { get; set; }

        public decimal? VbpIncentivePaymentPercentage { get; set; }

        public virtual Delivery Delivery { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utilization> Utilizations { get; set; }
    }
}
