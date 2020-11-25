using System.Data;

namespace TanmiahDatabase.Services
{
    public interface IBreadcrumbServices
    {
        DataTable GetBreadcrumb(int id);
    }
}