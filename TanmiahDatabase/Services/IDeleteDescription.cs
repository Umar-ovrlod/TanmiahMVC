using System.Data.SqlClient;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface IDeleteDescription
    {
        SqlDataReader DeleteDescData(int id, DescriptionModel descModel);
    }
}