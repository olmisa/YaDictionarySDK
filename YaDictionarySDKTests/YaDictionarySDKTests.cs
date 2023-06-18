using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using FluentAssertions;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using YaDictionarySDK;
using YaDictionarySDK.Web;
using YaDictionarySDK.Common;
using YaDictionarySDK.Web.Interfaces;
using System.Threading;

namespace YaDictionarySDKTests
{
    [TestClass]
    public class YaDictionarySDKTests
    {
        private static string apiKey;
        private static CancellationTokenSource tokenSource;

        [AssemblyInitialize]
        public static void Init(TestContext _textContext)
        {
            apiKey = Environment.GetEnvironmentVariable("YA_DICTIONARY_API_KEY");
            tokenSource = new CancellationTokenSource();
        }

        
        [DataRow("")]
        [DataRow(null)]
        [DataTestMethod]
        public async Task BadApiKeyTest(string _apiKey)
        {
            var yaSdk = new YaDictionary(_apiKey);
            Func<Task> getLanguagesTask = async () => { await yaSdk.GetLanguagesAsync(); };
            await getLanguagesTask.Should().ThrowAsync<YaDictionaryException>()
                .WithMessage(Constants.ExceptionMessages.ApiKeyIsEmpty);

            Func<Task> getTranslationTask = async () => { await yaSdk.GetTranslationAsync(string.Empty, string.Empty); };
            await getTranslationTask.Should().ThrowAsync<YaDictionaryException>()
                .WithMessage(Constants.ExceptionMessages.ApiKeyIsEmpty);
        }

        [TestMethod]
        public async Task InvalidLanguageTest()
        {
            var yaSdk = new YaDictionary(apiKey);
            Func<Task> getTranslationTask = async () => { await yaSdk.GetTranslationAsync(string.Empty, string.Empty); };
            await getTranslationTask.Should().ThrowAsync<YaDictionaryException>();
        }

        [TestMethod]
        public async Task InvalidWordTest()
        {
            var yaSdk = new YaDictionary(apiKey);
            Func<Task> getTranslationTask = async () => { await yaSdk.GetTranslationAsync(null, Constants.LanguagePairs.DeRu); };
            await getTranslationTask.Should().ThrowAsync<YaDictionaryException>();
        }

        [TestMethod]
        public async Task GetTranslationTest()
        {
            //prepare data
            string testDataContent = File.ReadAllText("Data/Traum.json");
            var response = JsonConvert.DeserializeObject<YaResponse>(testDataContent);
            var firstDef = response.Def[0];
            var expectedValues = firstDef.Translations.Select(translation => translation.Text).ToList();

            //get current data
            var yaSdk = new YaDictionary(apiKey);
            var currentValues = await yaSdk.GetTranslationAsync("Traum", Constants.LanguagePairs.DeRu);
            currentValues.Should().Equal(expectedValues);

            currentValues = await yaSdk.GetTranslationAsync("Traum", Constants.LanguagePairs.DeRu, tokenSource.Token);
            currentValues.Should().Equal(expectedValues);
        }

        [TestMethod]
        public async Task GetTranslationFullResponseTest()
        {
            //prepare data
            string testDataContent = File.ReadAllText("Data/Traum.json");
            var expectedResponse = JsonConvert.DeserializeObject<YaResponse>(testDataContent);

            //get current data
            var yaSdk = new YaDictionary(apiKey);
            var currentResponse = await yaSdk.GetTranslationFullResponseAsync("Traum", Constants.LanguagePairs.DeRu);
            currentResponse.Should().BeEquivalentTo(expectedResponse);

            currentResponse = await yaSdk.GetTranslationFullResponseAsync("Traum", Constants.LanguagePairs.DeRu, tokenSource.Token);
            currentResponse.Should().BeEquivalentTo(expectedResponse);
        }

        [TestMethod]
        public async Task GetLanguagesTest()
        {
            var expectedLangPairs = typeof(Constants.LanguagePairs).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly)
                .Select(fi => fi.GetValue(fi)?.ToString())
                .ToList();

            var yaSdk = new YaDictionary(apiKey);
            var currentLanguages = await yaSdk.GetLanguagesAsync();
            currentLanguages.Should().Contain(expectedLangPairs);

            currentLanguages = await yaSdk.GetLanguagesAsync(tokenSource.Token);
            currentLanguages.Should().Contain(expectedLangPairs);
        }
    }
}
