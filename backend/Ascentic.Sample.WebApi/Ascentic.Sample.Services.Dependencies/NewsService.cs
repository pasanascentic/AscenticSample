using Ascentic.Sample.Repositories;
using Ascentic.Sample.ViewModel.IO_Models;
using Ascentic.Sample.ViewModel.Models.News;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ascentic.Sample.Providers;

namespace Ascentic.Sample.Services.Dependencies
{
    public class NewsService : BaseService, INewsService
    {
        protected INewsProvider NewsProvider { get; set; }

        protected NewsService(INewsProvider newsProvider) : base()
        {
            NewsProvider = newsProvider;
        }
        
        public async Task<Output<List<NewsViewModel>>> GetNewsAsync()
        {
            // Business Logic goes here

            return await ExecuteBlockAsync(async () =>
            {
                return await NewsProvider.GetNewsAsync();
            }, (exception) => {
                return Output<List<NewsViewModel>>.FailOutput(exception.Message, description: exception.ToString());
            });
        }
    }
}
