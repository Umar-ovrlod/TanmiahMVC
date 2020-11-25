using System.Data.SqlClient;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface IDeleteList
    {
        SqlDataReader DeleteListData(int id, ListingModel listModel);
    }
}