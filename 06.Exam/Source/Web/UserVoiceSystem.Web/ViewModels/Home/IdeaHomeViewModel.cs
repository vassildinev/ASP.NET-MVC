namespace UserVoiceSystem.Web.ViewModels.Home
{
    using System;
    using System.Linq;

    using AutoMapper;
    using UserVoiceSystem.Data.Models;
    using UserVoiceSystem.Services.Web;
    using UserVoiceSystem.Web.Infrastructure.Mapping;

    public class IdeaHomeViewModel : IMapFrom<Idea>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Votes { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Ideas/ById/{identifier.EncodeId(this.Id)}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Idea, IdeaHomeViewModel>()
                .ForMember(x => x.Votes, opt => opt.MapFrom(x => x.Votes.Any() ? x.Votes.Sum(y => y.Value) : 0));
        }
    }
}
