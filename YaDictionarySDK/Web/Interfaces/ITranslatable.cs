using System.Collections.Generic;

namespace YaDictionarySDK.Web.Interfaces
{
    public interface ITranslatable
    {
        List<ITranslation> Translations { get; }
    }
}
