using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface IReadBanner
    {
        BannerModel ReadData(int id);
    }
}