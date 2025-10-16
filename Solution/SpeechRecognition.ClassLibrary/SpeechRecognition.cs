using System.Speech.Recognition;
using System.Speech.Synthesis; 

namespace SpeechRecognition.ClassLibrary
{
    public class SpeechRecognition
    {
        #region fields

        private string _inputText;

        #endregion

        #region constructors

        public SpeechRecognition()
        {
            _inputText = "Testing";
        }

        #endregion

        #region public methods

        public static void SynthesiseText(string input)
        {

        }

        #endregion

        #region private methods

        private static void SpeakTextInput(string input)
        {
            // Create a new SpeechRecognitionEngine instance.
            using SpeechRecognizer recognizer = new SpeechRecognizer();
            using ManualResetEvent exit = new ManualResetEvent(false);

            // Create a simple grammar that recognizes "red", "green", "blue", or "exit".
            Choices choices = new Choices();
            choices.Add(new string[] { "red", "green", "blue", "exit" });

            // Create a GrammarBuilder object and append the Choices object.
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(choices);

            // Create the Grammar instance and load it into the speech recognition engine.
            Grammar g = new Grammar(gb);
            recognizer.LoadGrammar(g);

            // Register a handler for the SpeechRecognized event.
            recognizer.SpeechRecognized += (s, e) =>
            {
                Console.WriteLine($"Recognized: {e.Result.Text}, Confidence: {e.Result.Confidence}");
                if (e.Result.Text == "exit")
                {
                    exit.Set();
                }
            };

            // Emulate
            Console.WriteLine("Emulating \"red\".");
            recognizer.EmulateRecognize("red");

            Console.WriteLine("Speak red, green, blue, or exit please...");

            exit.WaitOne();
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
