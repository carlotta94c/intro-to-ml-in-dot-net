using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ML;
using System;
using static TextClassifierRazor.TextClassifier;

namespace TextClassifierRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private PredictionEnginePool<ModelInput, ModelOutput> _predictionEnginePool;

        public IndexModel(ILogger<IndexModel> logger, PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool)
        {
            _logger = logger;
            _predictionEnginePool = predictionEnginePool;
        }

        public void OnGet()
        {

        }

        public IActionResult OnGetAnalyzeNews([FromQuery] string text)
        {
            if (String.IsNullOrEmpty(text)) return Content("Checking");

            var input = new ModelInput { Title = text };

            var prediction = _predictionEnginePool.Predict(input);

            var isReal = Convert.ToBoolean(prediction.PredictedLabel) ? "Real" : "Fake";

            return Content(isReal);
        }
    }
}