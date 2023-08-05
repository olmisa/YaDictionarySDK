using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using YaDictionarySDK;
using YaDictionarySDK.Common;
using YaDictionarySDK.Web;

namespace YaDictionarySDKTests
{
    [TestClass]
    public class YaDictionarySDKSyncTests
    {
        private static string apiKey;

        [ClassInitialize]
        public static void Init(TestContext _textContext)
        {
            apiKey = Environment.GetEnvironmentVariable("YA_DICTIONARY_API_KEY");
        }


        [DataRow("")]
        [DataRow(null)]
        [DataTestMethod]
        public void BadApiKeyTest(string _apiKey)
        {
            var yaSdk = new YaDictionary(_apiKey);
            Action action = () => yaSdk.GetLanguages();
            action.Should().Throw<YaDictionaryException>()
                .WithMessage(Constants.ExceptionMessages.ApiKeyIsEmpty);
        }

        [TestMethod]
        public void InvalidLanguageTest()
        {
            var yaSdk = new YaDictionary(apiKey);
            Action action = () => yaSdk.GetTranslation(string.Empty, string.Empty);
            action.Should().Throw<YaDictionaryException>();
        }

        [TestMethod]
        public void InvalidWordTest()
        {
            var yaSdk = new YaDictionary(apiKey);
            Action action = () => yaSdk.GetTranslation(null, Constants.LanguagePairs.DeRu);
            action.Should().Throw<YaDictionaryException>();
        }

        [TestMethod]
        public void GetTranslationTest()
        {
            //prepare data
            string testDataContent = File.ReadAllText("Data/Traum.json");
            var response = JsonConvert.DeserializeObject<YaResponse>(testDataContent);
            var firstDef = response.Def[0];
            var expectedValues = firstDef.Translations.Select(translation => translation.Text).ToList();

            //get current data
            var yaSdk = new YaDictionary(apiKey);
            var currentValues = yaSdk.GetTranslation("Traum", Constants.LanguagePairs.DeRu);
            currentValues.Should().Equal(expectedValues);

            currentValues = yaSdk.GetTranslation("Traum", Constants.LanguagePairs.DeRu);
            currentValues.Should().Equal(expectedValues);
        }

        [TestMethod]
        public void GetTranslationFullResponseTest()
        {
            //prepare data
            string testDataContent = File.ReadAllText("Data/Traum.json");
            var expectedResponse = JsonConvert.DeserializeObject<YaResponse>(testDataContent);

            //get current data
            var yaSdk = new YaDictionary(apiKey);
            var currentResponse = yaSdk.GetTranslationFullResponse("Traum", Constants.LanguagePairs.DeRu);
            currentResponse.Should().BeEquivalentTo(expectedResponse);

            currentResponse = yaSdk.GetTranslationFullResponse("Traum", Constants.LanguagePairs.DeRu);
            currentResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [TestMethod]
        public void GetLanguagesTest()
        {
            var expectedLangPairs = typeof(Constants.LanguagePairs).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly)
                .Select(fi => fi.GetValue(fi)?.ToString())
                .ToList();

            var yaSdk = new YaDictionary(apiKey);
            var currentLanguages = yaSdk.GetLanguages();
            currentLanguages.Should().Contain(expectedLangPairs);

            currentLanguages = yaSdk.GetLanguages();
            currentLanguages.Should().Contain(expectedLangPairs);
        }
    }
}
