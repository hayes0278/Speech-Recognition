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
                result = $"I could not find that command \"{inputCommand}\".";
                Console.WriteLine(result);
                return result;
            }

            if (_result.Text == inputCommand)
            {
                result = $"I recognised \"{inputCommand}\" with a confidense of {_result.Confidence * 100.00}%.";
                Console.WriteLine(result);
            } else
            {
                result = $"I dont understand the command: \"{inputCommand}\".";
                Console.WriteLine(result);
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

        public string[] CommandChoices
        {
            get { return _commandChoices; }
            set { _commandChoices = value; }
        }

        #endregion

        #region deconstructors
        #endregion
    }
}
