using Microsoft.AspNetCore.Mvc;
using SpeechRecognition.ClassLibrary;

namespace SpeechRecognition.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeechSynthesisController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<SpeechSynthesisController> _logger;

        public SpeechSynthesisController(ILogger<SpeechSynthesisController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCommands")]
        public IEnumerable<Speech> GetCommands()
        {
            return Enumerable.Range(1, Summaries.Length).Select(index => new Speech
            {
                Name = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(Name = "GetActions")]
        public IEnumerable<Speech> GetActions()
        {
            return Enumerable.Range(1, Summaries.Length).Select(index => new Speech
            {
                Name = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
