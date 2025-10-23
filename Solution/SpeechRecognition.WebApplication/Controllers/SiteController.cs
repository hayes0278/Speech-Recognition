using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SpeechRecognition.ClassLibrary;
using SpeechRecognition.WebApplication.Models;
using System.Diagnostics;

namespace SpeechRecognition.WebApplication.Controllers
{
    public class SiteController : Controller
    {
        private readonly ILogger<SiteController> _logger;
        private readonly IStringLocalizer<SiteController> _localizer;

        public SiteController(ILogger<SiteController> logger, IStringLocalizer<SiteController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            string formProcessed = Request.Query["btnSubmit"];

            if (formProcessed != null && formProcessed.ToLower() == "synthesise")
            {
                string selectCommand = Request.Query["selCommand"];
                string selectAction = Request.Query["selAction"];

                if (string.IsNullOrEmpty(selectCommand) || string.IsNullOrEmpty(selectAction))
                {
                    ViewBag.Message = "Please enter a command and action to simulate the recognition.";
                }

                SpeechRecognitionApp recogniser = new SpeechRecognitionApp();
                bool result = recogniser.RecogniseInputCommand(selectCommand);

                ViewBag.Command = selectCommand;
                ViewBag.Action = selectAction;

                ViewBag.TestTranslation = _localizer["welcome_to"];
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}