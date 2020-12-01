using System.Data.SqlClient;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface IEditBanner
    {
        SqlCommand EditData(BannerModel bannerModel, string statement);
    }
}