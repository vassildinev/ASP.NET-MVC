namespace UserVoiceSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using UserVoiceSystem.Common;

    public class Vote : BaseModel<int>
    {
        private ICollection<Idea> ideas;

        public Vote()
            : base()
        {
            this.ideas = new HashSet<Idea>();
        }

        [Required]
        [Range(GlobalConstants.MinVoteValue, GlobalConstants.MaxVoteValue)]
        public short Value { get; set; }

        [Required]
        [RegularExpression(
            @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b",
            ErrorMessage = GlobalConstants.InvalidIpAddressErrorMessage)]
        public string VoterIpAddress { get; set; }

        public virtual ICollection<Idea> Ideas
        {
            get { return this.ideas; }
            set { this.ideas = value; }
        }
    }
}
