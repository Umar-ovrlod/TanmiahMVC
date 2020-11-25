using System.Data;

namespace TanmiahDatabase.Services
{
    public interface ICardServices
    {
        DataTable GetCard(int id);
    }
}