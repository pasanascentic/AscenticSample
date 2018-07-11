using Ascentic.Sample.Entities;
using Ascentic.Sample.ViewModel.Models.News;

namespace Ascentic.Sample.Mapper
{
    public class AutoMapperConfig
    {

        public static void Initialize()
        {
            // Configuration 
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap <NewsViewModel, News>()
                .ForMember(d => d.Created, o => o.Ignore())
                .ForMember(d => d.Creator, o => o.Ignore())
                .ForMember(d => d.Edited, o => o.Ignore())
                .ForMember(d => d.Editor, o => o.Ignore())
                .ReverseMap();
            });

            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}
