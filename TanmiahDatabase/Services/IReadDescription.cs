using TanmiahDatabase.Models;

namespace TanmiahDatabase.Services
{
    public interface IReadDescription
    {
        DescriptionModel ReadDescData(int id);
    }
}