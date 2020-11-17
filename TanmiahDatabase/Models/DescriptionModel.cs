using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TanmiahDatabase.Models
{
    public class DescriptionModel
    {
        public int ProductID { get; set; }
        public string DescTitle { get; set; }
        public string DescText { get; set; }
        public string DescDec { get; set; }
        public string PerPack { get; set; }
        public string Energy { get; set; }
        public string Carbo { get; set; }
        public string Protiens { get; set; }
        public string Fat { get; set; }
        public string ProtiensPack { get; set;}
        public string FatPerPack { get; set; }
    }
}