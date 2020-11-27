using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TanmiahDatabase.Models
{
    public class ListingModel
    {
        public int ListingID{ get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 20)]
        [Display(Name = "Listing Image")]
        public string ListingImg { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [Display(Name = "Listing Product")]
        public string ListingProd { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [Display(Name = "Listing Product Title")]
        public string ListingProdTitle { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 20)]
        [Display(Name = "Listing Product Detail")]
        public string ListingDetail { get; set; }
    }
}