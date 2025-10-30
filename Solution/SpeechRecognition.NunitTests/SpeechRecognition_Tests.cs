using SpeechRecognition.ClassLibrary;

namespace SpeechRecognition.NunitTests
{
    public class Tests
    {
        [Test]
        public void RecogniseInputCommand_Test()
        {
            string command = "hello";
            SpeechRecognitionApp recogniser = new SpeechRecognitionApp();
            string actualResult = recogniser.RecogniseInputCommand(command);
            if (!string.IsNullOrEmpty(actualResult)) { Assert.Pass(); } else { Assert.Fail(); } ;
        }
    }
}