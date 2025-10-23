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

        public bool RecogniseInputCommand(string inputCommand)
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

            // Console.WriteLine("Type hello, red, green, blue, or exit please...");

            Console.WriteLine("Emulating \"${inputCommand}\".");
            RecognitionResult result = recognizer.EmulateRecognize(inputCommand);

            //exit.WaitOne();

            return true;
        }

        #endregion

        #region properties

        public string Command
        {
            get { return _command; }
            set { _command = value; }
        }

        #endregion

        #region deconstructors
        #endregion
    }
}
