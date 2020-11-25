using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface IReadCard
    {
        cardModel ReadCardData(int id);
    }
}