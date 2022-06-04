using System.Threading.Tasks;

namespace YaDictionarySDK.Methods
{
    internal interface IYaDictionaryMethod<T>
    {
        Task<T> GetResult();
    }
}
