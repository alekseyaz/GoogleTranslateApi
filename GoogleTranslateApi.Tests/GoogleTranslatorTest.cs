using NUnit.Framework;
using System.Threading.Tasks;
using Zaac.GoogleTranslateApi;
using Zaac.GoogleTranslateApi.Entities;

namespace GoogleTranslateApi.Tests
{
    public class GoogleTranslatorTest
    {
        private ITranslator _googleTranslator;

        [SetUp]
        public void Setup()
        {
            _googleTranslator = new GoogleTranslator();
        }

        [Test]
        public async Task TranslateAsync()
        {
            string sourceText = "TDD completely turned to traditional development.";
            TranslationResult transResult = await _googleTranslator.TranslateAsync(sourceText, "en", "ru");
            Assert.AreEqual("TDD полностью превратился в традиционную разработку.", transResult.TargetText);

            sourceText = "How are you doing today?";
            transResult = await _googleTranslator.TranslateAsync(sourceText, "ru", "en");
            Assert.AreEqual("How are you doing today?", transResult.TargetText);

            sourceText = "hello\"";
            transResult = await _googleTranslator.TranslateAsync(sourceText, "en", "ru");
            Assert.AreEqual("Здравствуйте\"", transResult.TargetText);

            sourceText = "hello";
            transResult = await _googleTranslator.TranslateAsync(sourceText, "en", "ru");
            Assert.AreEqual("Здравствуйте", transResult.TargetText);

            sourceText = "It's a very small project and may be fairly self explanatory if you are familiar with Visual Studio editor extensions. There are two components to the extension:";
            transResult = await _googleTranslator.TranslateAsync(sourceText, "en", "ru");
            Assert.AreEqual("Это очень небольшой проект, и он может быть достаточно понятным, если вы знакомы с расширениями редактора Visual Studio. Расширение состоит из двух компонентов:", transResult.TargetText);


            sourceText = "<result>";
            transResult = await _googleTranslator.TranslateAsync(sourceText, "en", "ru");
            Assert.AreEqual("<результат>", transResult.TargetText);
        }
    }
}
