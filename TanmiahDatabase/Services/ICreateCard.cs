using System.Data.SqlClient;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface ICreateCard
    {
        SqlDataReader GenerateCard(cardModel card);
    }
}