using System.Data.SqlClient;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface ICreateDescription
    {
        SqlDataReader CreateDesc(DescriptionModel descModel);
    }
}