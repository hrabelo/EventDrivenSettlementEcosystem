using System.Threading.Tasks;

namespace ESDE.AssetCheck.Domain.Interfaces
{
    public interface IEventBus
    {
        Task Publish<T>(T content) where T : class;
    }
}
