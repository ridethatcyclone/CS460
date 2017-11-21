namespace HW6
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Production.ProductReview")]
    public partial class ProductReview
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductReviewID { get; set; }

        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Name")]
        public string ReviewerName { get; set; }

        public DateTime ReviewDate { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }

        [Range(0,5)]
        public int Rating { get; set; }

        [StringLength(3850)]
        public string Comments { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
