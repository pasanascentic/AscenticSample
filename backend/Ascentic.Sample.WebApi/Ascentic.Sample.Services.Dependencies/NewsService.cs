using Ascentic.Sample.ViewModel.IO_Models;
using Ascentic.Sample.ViewModel.Models.News;
using System.Threading.Tasks;

namespace Ascentic.Sample.Services.Dependencies
{
    public class NewsService : BaseService, INewsService
    {
        protected NewsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        public Task<Output<NewsViewModel>> GetNewsAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
