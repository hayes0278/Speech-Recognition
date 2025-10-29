using SpeechRecognition.ClassLibrary;

namespace SpeechRecognition.NunitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RecogniseInputCommand_Test()
        {
            string command = "hello";
            SpeechRecognitionApp recogniser = new SpeechRecognitionApp();
            string actualResult = recogniser.RecogniseInputCommand(command);
            if (!string.IsNullOrEmpty(actualResult)) { Assert.Pass(); } else { Assert.Fail(); } ;
        }

        [Test]
        public void Test2()
        {
            Assert.Pass();
        }

        [Test]
        public void Test3()
        {
            Assert.Pass();
        }

        [Test]
        public void Test4()
        {
            Assert.Pass();
        }
    }
}