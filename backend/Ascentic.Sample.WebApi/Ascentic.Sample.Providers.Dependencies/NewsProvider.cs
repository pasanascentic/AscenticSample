using Ascentic.Sample.Repositories;
using Ascentic.Sample.ViewModel.IO_Models;
using Ascentic.Sample.ViewModel.Models.News;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ascentic.Sample.Providers.Dependencies
{
    public class NewsProvider : BaseProvider, INewsProvider
    {
        protected NewsProvider(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Output<List<NewsViewModel>>> GetNewsAsync()
        {
            // Get data from repo

            return await ExecuteBlockAsync(async () =>
            {
                var newsViewModels = new List<NewsViewModel>();

                // Get news 
                var news = await UnitOfWork.News.Get(a => a.ExpireDate >= DateTime.UtcNow);

                foreach (var n in news)
                {
                    newsViewModels.Add(Mapper.Map<NewsViewModel>(n));
                }

                return new Output<List<NewsViewModel>>
                {
                    Sucess = true,
                    Result = newsViewModels
                };
            }, (exception) => {
                return Output<List<NewsViewModel>>.FailOutput(exception.Message, description: exception.ToString());
            });
        }
    }
}
