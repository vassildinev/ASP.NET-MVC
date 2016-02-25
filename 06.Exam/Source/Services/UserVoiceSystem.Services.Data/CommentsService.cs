namespace UserVoiceSystem.Services.Data
{
    using System;
    using System.Linq;
    using UserVoiceSystem.Data.Common;
    using UserVoiceSystem.Data.Models;

    public class CommentsService : ICommentsService
    {
        private IDbRepository<Comment> comments;

        public CommentsService(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public IQueryable<Comment> All()
        {
            return this.comments.All();
        }

        public void Create(Comment comment)
        {
            this.comments.Add(comment);
        }

        public void Delete(Comment comment)
        {
            this.comments.Delete(comment);
        }

        public Comment GetById(int id)
        {
            return this.comments.GetById(id);
        }

        public void SaveChanges()
        {
            this.comments.Save();
        }

        public void Update(Comment comment)
        {
            var databasebComment = this.comments.GetById(comment.Id);
            if (!string.IsNullOrEmpty(comment.AuthorEmail))
            {
                databasebComment.AuthorEmail = comment.AuthorEmail;
            }

            if (!string.IsNullOrEmpty(comment.Content))
            {
                databasebComment.Content = comment.Content;
            }

            this.comments.Save();
        }
    }
}
