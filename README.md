# YaDictionarySDK

YaDictionarySDK is a .NETStandard2.0 and .NETFramework C# library which provides access for Yandex Dictionary API:

https://yandex.com/dev/dictionary/

This project includes C# library with methods for Yandex Dictionary API and unit tests for this code.

# How to use

```CSharp
var yaSdk = new YaDictionary(apiKey);
var languages = await yaSdk.GetLanguagesAsync();
    
string languagePair = "de-ru";
string wordToTranslate = "Traum";
var translation = await yaSdk.GetTranslationAsync(wordToTranslate, languagePair);
```

# Prerequisites

Requires .NET Framework 4.5 or higher or .NET Core, .NetStandard. HttpClient was used in this library.
The Api key for tests should be placed into environment variable with name "YA_DICTIONARY_API_KEY".

# Terms of Use

As decribed in the <a href="https://yandex.com/legal/dictionary_api/">Terms of Use for Yandex Dictionary service</a> the following text: “Powered by Yandex.Dictionary” with the clickable hyperlink to the page http://api.yandex.com/dictionary must be shown strictly over or under the dictionary articles.
