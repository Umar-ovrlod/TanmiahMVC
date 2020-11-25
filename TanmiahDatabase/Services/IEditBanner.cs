using System.Data.SqlClient;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface IEditBanner
    {
        SqlDataReader EditData(BannerModel bannerModel, string statement);
    }
}