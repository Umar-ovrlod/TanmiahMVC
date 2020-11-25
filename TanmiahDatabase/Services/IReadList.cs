using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface IReadList
    {
        ListingModel ReadListData(int id);
    }
}