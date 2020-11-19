using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Connect
{
    public static class Sql
    {
        public static string ConnectionString
        {
            get
            {
                string con=ConfigurationManager.ConnectionStrings["FoodDbContext"].ConnectionString;
                return con;
            }
        }
    }
}
