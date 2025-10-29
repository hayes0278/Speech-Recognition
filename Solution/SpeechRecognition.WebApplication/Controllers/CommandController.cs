using Microsoft.AspNetCore.Mvc;
using SpeechRecognition.ClassLibrary;

namespace SpeechRecognition.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<SpeechRecognitionController> _logger;

        public CommandController(ILogger<SpeechRecognitionController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCommands")]
        public IEnumerable<Speech> GetCommands()
        {
            SpeechRecognitionApp app = new SpeechRecognitionApp();

            return Enumerable.Range(0, app.CommandChoices.Length).Select(index => new Speech
            {
                Name = app.CommandChoices[index]
            })
            .ToArray();
        }
    }
}
