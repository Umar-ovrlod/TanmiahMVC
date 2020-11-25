using System.Data;

namespace TanmiahDatabase.Services
{
    public interface IDescriptionServices
    {
        DataTable GetDescription(int id);
    }
}