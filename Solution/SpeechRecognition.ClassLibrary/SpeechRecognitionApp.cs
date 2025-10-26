using System.Speech.Recognition;
using System.Speech.Synthesis; 

namespace SpeechRecognition.ClassLibrary
{
    public class SpeechRecognitionApp
    {
        #region fields

        private string _command;
        private string _action;
        private string[] _commandChoices = { "hello", "red", "green", "blue", "exit" };
        private string _result;

        #endregion

        #region constructors

        public SpeechRecognitionApp()
        {
            
        }

        #endregion

        #region public methods

        public bool LoadGrammar(string[] inputGrammar)
        {
            return true;
        }

        #endregion

        #region private methods

        public string RecogniseInputCommand(string inputCommand)
        {
            // Create a new SpeechRecognitionEngine instance.
            using SpeechRecognizer recognizer = new SpeechRecognizer();
            using ManualResetEvent exit = new ManualResetEvent(false);

            string result = null;

            Choices choices = new Choices();
            choices.Add(_commandChoices);

            GrammarBuilder grammerBuilder = new GrammarBuilder();
            grammerBuilder.Append(choices);

            Grammar grammer = new Grammar(grammerBuilder);
            recognizer.LoadGrammar(grammer);

            Console.WriteLine($"Emulating \"{inputCommand}\".");
            RecognitionResult _result = recognizer.EmulateRecognize(inputCommand);

            if (_result == null)
            {
                Console.WriteLine("Speech recogniser offline.");
                result = "The speech recogniser is offline.";
                return result;
            }

            if (_result.Text == inputCommand)
            {
                Console.WriteLine($"Recognised \"{inputCommand}\".");
                result = $"Recognised \"{inputCommand}\" with a confidense of {_result.Confidence * 100.00} .";
            } else
            {
                Console.WriteLine($"I dont understand the command: \"{inputCommand}\".");
                result = $"I dont understand the command: \"{inputCommand}\".";
            }

            return result;
        }

        #endregion

        #region properties

        public string Command
        {
            get { return _command; }
            set { _command = value; }
        }

        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }

        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }

        #endregion

        #region deconstructors
        #endregion
    }
}
