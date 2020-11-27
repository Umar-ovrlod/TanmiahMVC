using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TanmiahDatabase.Models
{
    public class cardModel
    {
        public int CardId { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 20)]
        [Display(Name = "Card Image")]
        public string CardImage { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 20)]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 25)]
        [Display(Name = "Short Text")]
        public string ShortText { get; set; }
        [Required]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }
    }
}