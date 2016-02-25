namespace UserVoiceSystem.Services.Data
{
    using System.Linq;
    using UserVoiceSystem.Data.Models;

    public interface ICommentsService
    {
        Comment GetById(int id);

        IQueryable<Comment> All();

        void Update(Comment comment);

        void Delete(Comment comment);

        void Create(Comment comment);

        void SaveChanges();
    }
}
