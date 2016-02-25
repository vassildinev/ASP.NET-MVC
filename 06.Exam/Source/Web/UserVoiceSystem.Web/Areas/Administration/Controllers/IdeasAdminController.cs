namespace UserVoiceSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Services.Data;
    using UserVoiceSystem.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class IdeasAdminController : BaseController
    {
        private IIdeasService ideas;

        public IdeasAdminController(IIdeasService ideas)
            : base()
        {
            this.ideas = ideas;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var ideas = this.ideas
                .All()
                .To<IdeaViewModel>();

            return this.Json(ideas.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, IdeaViewModel idea)
        {
            if (idea != null && this.ModelState.IsValid)
            {
                this.ideas.Update(new Idea()
                {
                    Title = idea.Title,
                    Id = idea.Id,
                    Description = idea.Description
                });

                this.ideas.SaveChanges();
            }

            return this.Json(new[] { idea }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, IdeaViewModel idea)
        {
            var databaseIdea = this.ideas.GetById(idea.Id);

            if (idea != null)
            {
                this.ideas.Delete(databaseIdea);
                this.ideas.SaveChanges();
            }

            return this.Json(new[] { idea }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, IdeaViewModel idea)
        {
            if (idea != null && this.ModelState.IsValid)
            {
                this.ideas.Create(new Idea() { Title = idea.Title, Description = idea.Description });
                this.ideas.SaveChanges();
            }

            return this.Json(new[] { idea }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
