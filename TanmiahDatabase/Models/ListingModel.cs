using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TanmiahDatabase.Models
{
    public class ListingModel
    {
        public int ListingID{ get; set; }
        public string ListingImg { get; set; }
        public string ListingProd { get; set; }
        public string ListingProdTitle { get; set; }
        public string ListingDetail { get; set; }
    }
}