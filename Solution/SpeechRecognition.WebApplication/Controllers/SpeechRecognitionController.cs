using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SpeechRecognition.ClassLibrary;

namespace SpeechRecognition.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeechRecognitionController : ControllerBase
    {
        private readonly ILogger<SpeechRecognitionController> _logger;
        private readonly IStringLocalizer<SpeechRecognitionController> _localizer;

        public SpeechRecognitionController(ILogger<SpeechRecognitionController> logger, IStringLocalizer<SpeechRecognitionController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
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
