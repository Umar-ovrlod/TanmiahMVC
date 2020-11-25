using System.Data.SqlClient;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface ICreateBanner
    {
        SqlDataReader CreateData(BannerModel bannerModel);
    }
}