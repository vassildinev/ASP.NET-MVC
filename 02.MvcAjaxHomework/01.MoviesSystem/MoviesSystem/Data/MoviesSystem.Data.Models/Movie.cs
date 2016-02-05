namespace MoviesSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public int Year { get; set; }

        [Display(Name = "Lead male")]
        public string LeadMaleRole { get; set; }

        [Display(Name = "Lead female")]
        public string LeadFemaleRole { get; set; }
    }
}
