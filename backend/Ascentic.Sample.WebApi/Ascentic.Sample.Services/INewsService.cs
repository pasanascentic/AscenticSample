using Ascentic.Sample.ViewModel.IO_Models;
using Ascentic.Sample.ViewModel.Models.News;
using System.Threading.Tasks;

namespace Ascentic.Sample.Services
{
    public interface INewsService : IBaseService
    {
        Task<Output<NewsViewModel>> GetNewsAsync();
    }
}
