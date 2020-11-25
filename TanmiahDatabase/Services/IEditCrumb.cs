using System.Data.SqlClient;
using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface IEditCrumb
    {
        SqlDataReader EditBread(BreadcrumbModel breadcrumb);
    }
}