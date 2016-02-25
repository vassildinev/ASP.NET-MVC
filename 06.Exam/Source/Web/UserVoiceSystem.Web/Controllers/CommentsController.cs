namespace UserVoiceSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Data.Models;
    using Ganss.XSS;
    using Services.Data;
    using ViewModels.Comments;

    public class CommentsController : Controller
    {
        private IIdeasService ideas;
        private Random random = new Random();

        public CommentsController(IIdeasService ideas, ICommentsService comments)
        {
            this.ideas = ideas;
        }

        [HttpPost]
        public ActionResult Create(CommentPostModel comment)
        {
            var idea = this.ideas.GetById(comment.Id);
            idea.Comments.Add(new Comment()
            {
                AuthorEmail = new HtmlSanitizer().Sanitize(comment.Email),
                Content = new HtmlSanitizer().Sanitize(comment.NewContent),
                AuthorIpAddress = this.GetRandomIpAddress()
            });

            this.ideas.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }

        private string GetRandomIpAddress()
        {
            const string IpAddressNumbersDivider = ".";
            string result = string.Join(IpAddressNumbersDivider, Enumerable.Repeat(this.random.Next(0, 256), 4));
            return result;
        }
    }
}
