using System.Data.SqlClient;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface IEditList
    {
        SqlDataReader EditListData(ListingModel ListModel);
    }
}