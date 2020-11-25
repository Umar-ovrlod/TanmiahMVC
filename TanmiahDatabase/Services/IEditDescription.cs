using System.Data.SqlClient;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface IEditDescription
    {
        SqlDataReader EditDescData(DescriptionModel descModel);
    }
}