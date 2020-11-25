using System.Data.SqlClient;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface IDeleteBanner
    {
        SqlDataReader DeleteData(int id, BannerModel bannerModel, string statement);
    }
}