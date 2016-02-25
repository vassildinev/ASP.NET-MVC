namespace UserVoiceSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using UserVoiceSystem.Common;

    public class Idea : BaseModel<int>
    {
        private ICollection<Vote> votes;
        private ICollection<Comment> comments;

        public Idea()
            : base()
        {
            this.votes = new HashSet<Vote>();
            this.comments = new HashSet<Comment>();
        }

        [Required]
        [MaxLength(300)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [RegularExpression(
            @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b",
            ErrorMessage = GlobalConstants.InvalidIpAddressErrorMessage)]
        public string AuthorIpAddress { get; set; }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
