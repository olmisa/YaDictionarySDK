using System.Threading;
using System.Threading.Tasks;

namespace YaDictionarySDK.Methods
{
    internal interface IYaDictionaryAsyncMethod<T>
    {
        Task<T> GetResult(CancellationToken? _cancellationToken);
    }
}
