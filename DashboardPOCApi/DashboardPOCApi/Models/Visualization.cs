namespace DashboardPOCApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DASHBOARD.Visualization")]
    public partial class Visualization
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string CCN { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ReportingQuarterID { get; set; }

        public Guid? FieldId { get; set; }

        public string BlobWebAddress { get; set; }

        public byte[] BlobPdf { get; set; }
    }
}
