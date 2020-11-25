using System.Data.SqlClient;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface ICreateList
    {
        SqlDataReader CreateProdList(ListingModel ListModel);
    }
}