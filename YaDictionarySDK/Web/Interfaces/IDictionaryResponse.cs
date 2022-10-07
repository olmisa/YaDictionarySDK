using System.Collections.Generic;

namespace YaDictionarySDK.Web.Interfaces
{
    public interface IDictionaryResponse
    {
        object Head { get; }
        List<IWordEntry> Def { get; }
    }
}
