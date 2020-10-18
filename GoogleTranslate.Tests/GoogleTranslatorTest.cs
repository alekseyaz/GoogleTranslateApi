using NUnit.Framework;
using System.Threading.Tasks;
using Zaac.GoogleTranslate;
using Zaac.GoogleTranslate.Entities;

namespace GoogleTranslate.Tests
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
            Assert.AreEqual("TDD ��������� ����������� � ������������ ����������.", transResult.TargetText);

            sourceText = "How are you doing today?";
            transResult = await _googleTranslator.TranslateAsync(sourceText, "ru", "en");
            Assert.AreEqual("How are you doing today?", transResult.TargetText);

            sourceText = "hello\"";
            transResult = await _googleTranslator.TranslateAsync(sourceText, "en", "ru");
            Assert.AreEqual("������������\"", transResult.TargetText);

            sourceText = "hello";
            transResult = await _googleTranslator.TranslateAsync(sourceText, "en", "ru");
            Assert.AreEqual("������������", transResult.TargetText);

            sourceText = "It's a very small project and may be fairly self explanatory if you are familiar with Visual Studio editor extensions. There are two components to the extension:";
            transResult = await _googleTranslator.TranslateAsync(sourceText, "en", "ru");
            Assert.AreEqual("��� ����� ��������� ������, � �� ����� ���� ���������� ��������, ���� �� ������� � ������������ ��������� Visual Studio. ���������� ������� �� ���� �����������:", transResult.TargetText);


            sourceText = "<result>";
            transResult = await _googleTranslator.TranslateAsync(sourceText, "en", "ru");
            Assert.AreEqual("<���������>", transResult.TargetText);
        }
    }
}