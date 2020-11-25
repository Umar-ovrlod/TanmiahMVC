using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface IReadCrumb
    {
        BreadcrumbModel Read(int id);
    }
}