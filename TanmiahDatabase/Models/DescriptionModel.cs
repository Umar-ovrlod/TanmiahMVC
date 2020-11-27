using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TanmiahDatabase.Models
{
    public class DescriptionModel
    {
        public int DescID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 20)]
        [Display(Name = "Description Title")]
        public string DescTitle { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 20)]
        [Display(Name = "Description Text")]
        public string DescText { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 20)]
        [Display(Name = "Description Declaration")]
        public string DescDec { get; set; }
        [Required]
        [StringLength(4, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Per Pack Gram")]
        public string PerPack { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Energy")]
        public string Energy { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Carbohydrates")]
        public string Carbo { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Protiens")]
        public string Protiens { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Fat")]
        public string Fat { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Protien Per Quantity")]
        public string ProtiensPerPack { get; set;}
        [Required]
        [StringLength(3, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Fat Per Pack")]
        public string FatPerPack { get; set; }
        [Required]
       // [StringLength(2, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "ProductID")]
        public int ProductID { get; set; }
    }
}