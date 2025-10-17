using System.Speech.Recognition;
using System.Speech.Synthesis; 

namespace SpeechRecognition.ClassLibrary
{
    public class SpeechRecognition
    {
        #region fields

        private string _inputText;
        private static string[] _commandChoices = { "red", "green", "blue", "exit" };

        #endregion

        #region constructors

        public SpeechRecognition()
        {
            _inputText = "Testing";
        }

        #endregion

        #region public methods

        public static bool LoadGrammar(string[] inputGrammar)
        {
            return true;
        }

        #endregion

        #region private methods

        public static bool RecogniseInputCommand(string inputCommand)
        {
            // Create a new SpeechRecognitionEngine instance.
            using SpeechRecognizer recognizer = new SpeechRecognizer();
            using ManualResetEvent exit = new ManualResetEvent(false);

            Choices choices = new Choices();
            choices.Add(_commandChoices);

            GrammarBuilder grammerBuilder = new GrammarBuilder();
            grammerBuilder.Append(choices);

            Grammar grammer = new Grammar(grammerBuilder);
            recognizer.LoadGrammar(grammer);

            Console.WriteLine("Speak red, green, blue, or exit please...");

            Console.WriteLine("Emulating \"red\".");
            recognizer.EmulateRecognize("red");

            //exit.WaitOne();

            return true;
        }

        #endregion

        #region properties

        public string InputText
        {
            get { return _inputText; }
            set { _inputText = value; }
        }

        #endregion

        #region deconstructors
        #endregion
    }
}
