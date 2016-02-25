namespace UserVoiceSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using UserVoiceSystem.Common;

    public class Comment : BaseModel<int>
    {
        public Comment()
            : base()
        {
        }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Required]
        [EmailAddress]
        public string AuthorEmail { get; set; }

        [Required]
        [RegularExpression(
            @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b",
            ErrorMessage = GlobalConstants.InvalidIpAddressErrorMessage)]
        public string AuthorIpAddress { get; set; }

        public int IdeaId { get; set; }

        public virtual Idea Idea { get; set; }
    }
}
