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
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class CommentsAdminController : BaseController
    {
        private ICommentsService comments;

        public CommentsAdminController(ICommentsService comments)
            : base()
        {
            this.comments = comments;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var comments = this.comments
                .All()
                .To<CommentViewModel>();

            return this.Json(comments.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, CommentViewModel comment)
        {
            if (comment != null && this.ModelState.IsValid)
            {
                this.comments.Update(new Comment()
                {
                    AuthorEmail = comment.AuthorEmail,
                    Id = comment.Id,
                    Content = comment.Content
                });

                this.comments.SaveChanges();
            }

            return this.Json(new[] { comment }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, CommentViewModel product)
        {
            var comment = this.comments.GetById(product.Id);

            if (product != null)
            {
                this.comments.Delete(comment);
                this.comments.SaveChanges();
            }

            return this.Json(new[] { product }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, CommentViewModel product)
        {
            if (product != null && this.ModelState.IsValid)
            {
                this.comments.Create(new Comment() { AuthorEmail = product.AuthorEmail, Content = product.Content });
                this.comments.SaveChanges();
            }

            return this.Json(new[] { product }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
