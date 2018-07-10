using System;
using Ascentic.Sample.Entities;

namespace Ascentic.Sample.ViewModel.Models.News
{
    public class NewsViewModel : IViewModel<NewsViewModel, Entities.News>
    {
        public string Message { get; set; }

        public DateTime ExpireDate { get; set; }

        public Entities.News ToEntity()
        {
            return new Entities.News
            {
                Message = Message,
                ExpireDate = ExpireDate
            };
        }

        public void ToModel(Entities.News entity)
        {
            Message = entity.Message;
            ExpireDate = entity.ExpireDate;
        }
    }
}
