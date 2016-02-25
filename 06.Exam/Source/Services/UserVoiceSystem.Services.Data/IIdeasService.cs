namespace UserVoiceSystem.Services.Data
{
    using System.Linq;

    using UserVoiceSystem.Data.Models;

    public interface IIdeasService
    {
        IQueryable<Idea> All();

        IQueryable<Idea> AllWithDeleted();

        void SaveChanges();

        void Add(Idea newIdea);

        Idea GetById(string id);

        Idea GetById(int id);

        void Update(Idea idea);

        void Delete(Idea comment);

        void Create(Idea idea);
    }
}
