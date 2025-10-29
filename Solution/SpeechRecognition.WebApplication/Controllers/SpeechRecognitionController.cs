using Microsoft.AspNetCore.Mvc;
using SpeechRecognition.ClassLibrary;

namespace SpeechRecognition.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeechRecognitionController : ControllerBase
    {
        private readonly ILogger<SpeechRecognitionController> _logger;

        public SpeechRecognitionController(ILogger<SpeechRecognitionController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "PostSpeechRecognition")]
        public string PostSpeechRecognition(string command)
        {
            SpeechRecognitionApp recogniser = new SpeechRecognitionApp();
            string result = recogniser.RecogniseInputCommand(command);
            return result;
        }
    }
}
