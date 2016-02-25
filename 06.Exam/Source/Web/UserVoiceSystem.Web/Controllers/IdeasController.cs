namespace UserVoiceSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Data;
    using Data.Models;
    using Ganss.XSS;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Services.Data;
    using ViewModels.Ideas;

    public class IdeasController : BaseController
    {
        private IIdeasService ideas;
        private Random random = new Random();

        public IdeasController(IIdeasService ideas)
            : base()
        {
            this.ideas = ideas;
        }

        [HttpPost]
        public ActionResult Create(IdeaPostViewModel idea)
        {
            var userManager = new UserManager<User>(new UserStore<User>(new UserVoiceSystemDbContext()));
            var newIdea = new Idea()
            {
                Title = new HtmlSanitizer().Sanitize(idea.Title),
                Description = new HtmlSanitizer().Sanitize(idea.Description)
            };

            var userId = this.User.Identity.GetUserId();
            if (userId != null)
            {
                var user = userManager.FindById(userId);
                newIdea.AuthorIpAddress = user.IpAddress;
            }
            else
            {
                newIdea.AuthorIpAddress = this.GetRandomIpAddress();
            }

            this.ideas.Add(newIdea);
            this.ideas.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var idea = this.ideas.GetById(id);
            var userManager = new UserManager<User>(new UserStore<User>(new UserVoiceSystemDbContext()));
            var userId = this.User.Identity.GetUserId();
            var user = userManager.FindById(userId);

            if (user.IpAddress != idea.AuthorIpAddress)
            {
                return this.RedirectToAction("Error", "Home");
            }

            this.ideas.Delete(idea);
            this.ideas.SaveChanges();
            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult ById(string id, int page = 1)
        {
            var idea = this.ideas.GetById(id);
            var viewModel = this.Mapper.Map<IdeaDetailedViewModel>(idea);
            viewModel.CommentsDetailed = viewModel
                .CommentsDetailed
                .OrderByDescending(c => c.CreatedOn)
                .Skip((page - 1) * 4)
                .Take(4)
                .ToList();
            return this.View(viewModel);
        }

        private string GetRandomIpAddress()
        {
            const string IpAddressNumbersDivider = ".";
            string result = string.Join(IpAddressNumbersDivider, Enumerable.Repeat(this.random.Next(0, 256), 4));
            return result;
        }
    }
}
