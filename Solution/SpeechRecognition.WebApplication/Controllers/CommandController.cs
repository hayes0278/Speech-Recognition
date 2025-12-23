using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SpeechRecognition.ClassLibrary;

namespace SpeechRecognition.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<CommandController> _logger;
        private readonly IStringLocalizer<CommandController> _localizer;

        public CommandController(ILogger<CommandController> logger, IStringLocalizer<CommandController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
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
