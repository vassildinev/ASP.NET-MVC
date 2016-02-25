namespace UserVoiceSystem.Web.ViewModels.Ideas
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;

    public class IdeaDetailedViewModel : IMapFrom<Idea>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ObfuscatedId
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return identifier.EncodeId(this.Id);
            }
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Votes { get; set; }

        public int Comments { get; set; }

        public ICollection<CommentViewModel> CommentsDetailed { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Idea, IdeaDetailedViewModel>()
                .ForMember(x => x.Votes, opt => opt.MapFrom(x => x.Votes.Any() ? x.Votes.Sum(y => y.Value) : 0));

            configuration.CreateMap<Idea, IdeaDetailedViewModel>()
                .ForMember(x => x.Comments, opt => opt.MapFrom(x => x.Comments.Count()));

            configuration.CreateMap<Idea, IdeaDetailedViewModel>()
                .ForMember(x => x.CommentsDetailed, opt => opt.MapFrom(x => x.Comments));
        }
    }
}
