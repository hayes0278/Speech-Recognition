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
        SpeechRecognitionApp _recogniser = new SpeechRecognitionApp();

        public SiteController(ILogger<SiteController> logger, IStringLocalizer<SiteController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            string formProcessed = Request.Query["btnSubmit"];

            if (formProcessed != null && formProcessed.ToLower() == "recognize")
            {
                string selectCommand = Request.Query["selCommand"];

                if (string.IsNullOrEmpty(selectCommand))
                {
                    ViewBag.Message = _localizer["Please enter a command and action to simulate the recognition."];
                }
                
                string myResult = _recogniser.RecogniseInputCommand(selectCommand);

                ViewBag.Command = selectCommand;
                ViewBag.Result = myResult;
            }

            ViewBag.AppName = _localizer["Speech Recognition"];
            ViewBag.AppTagLine = _localizer["A lightweight speech recognition web tool."];
            ViewBag.CommandChoices = _recogniser.CommandChoices;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}