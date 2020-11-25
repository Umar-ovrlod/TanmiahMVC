using System.Data.SqlClient;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface IEditCard
    {
        SqlDataReader EditCardData(cardModel card);
    }
}