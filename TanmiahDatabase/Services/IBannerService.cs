using System.Data;

namespace TanmiahDatabase.Services
{
    public interface IBannerService
    {
        DataTable GetDataTable(int id);
    }
}