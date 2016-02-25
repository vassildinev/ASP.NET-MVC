namespace UserVoiceSystem.Web.Areas.Administration.Models
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class IdeaViewModel : IMapFrom<Idea>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
