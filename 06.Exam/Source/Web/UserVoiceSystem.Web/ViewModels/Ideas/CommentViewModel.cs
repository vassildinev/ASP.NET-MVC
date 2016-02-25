namespace UserVoiceSystem.Web.ViewModels.Ideas
{
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Content { get; set; }

        public string AuthorEmail { get; set; }

        public string CreatedOn { get; set; }

        public string EscapedEmail
        {
            get
            {
                IEMailHiderService emailService = new EmailHiderService();
                return emailService.HideEmail(this.AuthorEmail);
            }
        }
    }
}
