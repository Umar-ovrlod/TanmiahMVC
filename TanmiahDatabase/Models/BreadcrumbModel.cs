using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TanmiahDatabase.Models
{
    public class BreadcrumbModel
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string ProductTitle { get; set; }
    }
}