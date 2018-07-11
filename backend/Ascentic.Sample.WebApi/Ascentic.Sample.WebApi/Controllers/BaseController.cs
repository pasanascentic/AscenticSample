using System;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ascentic.Sample.WebApi.Controllers
{
    public class BaseController : Controller
    {
        #region Services

        protected readonly TelemetryClient telemetryClient;

        public ILogger Logger { get; }

        public IConfiguration Configuration { get; }

        #endregion

        #region Properties
        
        #endregion

        public BaseController(IConfiguration configurationInstance, ILogger<Controller> loggerInstance)
        {
            Logger = loggerInstance;
            Configuration = configurationInstance;
            telemetryClient = new TelemetryClient();

            var appsettings = Configuration.GetSection("AppSettings");

            if (appsettings["APPINSIGHTS_INSTRUMENTATIONKEY"] != null)
            {
                telemetryClient.InstrumentationKey = appsettings["APPINSIGHTS_INSTRUMENTATIONKEY"];
            }
        }

        #region Excutions

        public async Task<IActionResult> ExecuteTaskAsync([FromBody]Func<Task<IActionResult>> func)
        {
            try
            {
                return await func.Invoke();
            }
            catch (Exception exception)
            {
                // TODO: Log the error

                // Use default logger to log the exceptions
                Logger.LogError(exception, exception.Message);

                // Application Insights track exceptions
                telemetryClient.TrackException(exception);

                // Indicate internal server error
                return StatusCode(500, exception);
            }
        }

        public IActionResult ExecuteTask(Func<IActionResult> func)
        {
            try
            {
                return func.Invoke();
            }
            catch (Exception exception)
            {
                // TODO: Log the error

                // Use default logger to log the exceptions
                Logger.LogError(exception, exception.Message);

                // Application Insights track exceptions
                telemetryClient.TrackException(exception);

                // Indicate internal server error
                return StatusCode(500, exception);
            }
        }

        #endregion
    }
}