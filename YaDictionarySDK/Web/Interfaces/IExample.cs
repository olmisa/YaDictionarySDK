using System.Collections.Generic;

namespace YaDictionarySDK.Web.Interfaces
{
    public interface IExample : IText
    {
        List<IText> Tr { get; }
    }
}
