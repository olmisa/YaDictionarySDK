using System.Collections.Generic;

namespace YaDictionarySDK.Web.Interfaces
{
    public interface ISynonymable
    {
        List<ISynonym> Syn { get; }
    }
}
