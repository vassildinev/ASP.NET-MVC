namespace UserVoiceSystem.Web.Areas.Administration.Models
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string AuthorEmail { get; set; }

        public string Content { get; set; }
    }
}
