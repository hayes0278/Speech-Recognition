using System.Speech.Recognition;

namespace SpeechRecognition.ClassLibrary
{
    public class SpeechRecognitionApp
    {
        #region fields
        private string _command;
        private string _action;
        private string[] _commandChoices = { "hello", "red", "green", "blue", "purple", "alert", "message", "white", "black", "exit" };
        private string _result;
        #endregion

        #region public methods
        public string RecogniseInputCommand(string inputCommand)
        {
            using SpeechRecognizer recognizer = new SpeechRecognizer();
            using ManualResetEvent exit = new ManualResetEvent(false);

            string result = null;

            Choices choices = new Choices();
            choices.Add(_commandChoices);

            GrammarBuilder grammerBuilder = new GrammarBuilder();
            grammerBuilder.Append(choices);

            Grammar grammer = new Grammar(grammerBuilder);
            recognizer.LoadGrammar(grammer);

            RecognitionResult _result = recognizer.EmulateRecognize(inputCommand.ToLower().Trim());

            if (_result == null)
            {
                result = $"I did not recognise that command \"{inputCommand}\".";
                return result;
            }

            if (_result.Text == inputCommand.ToLower())
            {
                result = $"I recognised \"{inputCommand}\" with a confidense of {_result.Confidence * 100.00}%.";
            }
            else
            {
                result = $"I dont understand that command: \"{inputCommand}\".";
            }

            return result;
        }
        #endregion

        #region private methods
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
    }
}
