using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TanmiahDatabase.Models
{
    public class cardModel
    {
        public int CardId { get; set; }
        public string CardImage { get; set; }
        public string ShortDescription { get; set; }
        public string ShortText { get; set; }
        public int ProductID { get; set; }


    }
}