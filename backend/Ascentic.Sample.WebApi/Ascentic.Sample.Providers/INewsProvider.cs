using Ascentic.Sample.ViewModel.IO_Models;
using Ascentic.Sample.ViewModel.Models.News;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ascentic.Sample.Providers
{
    public interface INewsProvider : IBaseProvider
    {
        Task<Output<List<NewsViewModel>>> GetNewsAsync();
    }
}
