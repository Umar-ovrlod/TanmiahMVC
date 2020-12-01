using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TanmiahDatabase.Models
{
    public class BannerModel
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [Display(Name ="Product Type")]
        public string ProductType { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [Display(Name = "Product Title")]
        public string ProductTitle { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 20)]
        [Display(Name ="Product Description")]
        public string ProductDescription { get; set; }
        //[DisplayName("Product Image")]
        [DataType(DataType.Upload)]
        public string ProductImage { get; set; }

    }
}