using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;//The Standard way

        private readonly ILogger _logger;// to change logger name

        ////The Standard way of capturing the category
        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public IndexModel(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger("DemoCategory"); // to change logger name
        }

        public void OnGet()
        {
            //////The Logging Levels
            _logger.LogTrace("This is a trace Log");
            _logger.LogDebug("This is a Debug Log");
            _logger.LogInformation("This is a information Log");
            _logger.LogWarning("This is a warning Log");
            _logger.LogError("This is a Error Log");
            _logger.LogCritical("This is a critical log ");
            _logger.LogInformation(LoggingId.Democode, "This is our first watched message.....!");

            //////Advanced Logging Messages
            //_logger.LogError("The Server Went Down Temperorily at {Time}", DateTime.Now);

            //try
            //{
            //    throw new Exception("You forgot to catch me");
            //}
            //catch(Exception ex)
            //{

            //    _logger.LogCritical(ex, "There was a bad exception at {Time}", DateTime.Now);
            //}
        }
    }

    public class LoggingId
    {
        public const int Democode = 1001;
    }
}
