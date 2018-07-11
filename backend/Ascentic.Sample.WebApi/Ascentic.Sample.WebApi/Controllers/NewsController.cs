using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascentic.Sample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Ascentic.Sample.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : BaseController
    {
        #region Business Logics

        public INewsService NewsService { get; set; }

        #endregion

        public NewsController(IConfiguration configuration,
            ILogger<NewsController> loggerController,
            INewsService newsService)
            : base(configuration, loggerController)
        {
            NewsService = newsService;
        }

        // GET api/news
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExecuteTaskAsync(async () =>
            {
                // Get News
                var news = await NewsService.GetNewsAsync();

                // Return News
                return Ok(news);
            });
        }
    }
}