using System.Data.SqlClient;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface IDeleteCard
    {
        SqlDataReader DeleteCardData(cardModel card, int id);
    }
}