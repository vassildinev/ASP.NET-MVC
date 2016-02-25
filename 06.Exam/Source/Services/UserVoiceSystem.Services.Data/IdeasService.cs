namespace UserVoiceSystem.Services.Data
{
    using System;
    using System.Linq;

    using UserVoiceSystem.Data.Common;
    using UserVoiceSystem.Data.Models;
    using Web;

    public class IdeasService : IIdeasService
    {
        private IDbRepository<Idea> ideas;
        private IIdentifierProvider identifierProvider;
        private ICommentsService comments;

        public IdeasService(IDbRepository<Idea> ideas, IIdentifierProvider identifierProvider, ICommentsService comments)
        {
            this.ideas = ideas;
            this.identifierProvider = identifierProvider;
            this.comments = comments;
        }

        public void Add(Idea newIdea)
        {
            this.ideas.Add(newIdea);
        }

        public IQueryable<Idea> All()
        {
            return this.ideas.All();
        }

        public IQueryable<Idea> AllWithDeleted()
        {
            return this.ideas.AllWithDeleted();
        }

        public void Create(Idea idea)
        {
            this.Add(idea);
        }

        public void Delete(Idea idea)
        {
            var databaseIdea = this.GetById(idea.Id);

            foreach (var item in databaseIdea.Comments)
            {
                this.comments.Delete(item);
            }

            this.ideas.Delete(databaseIdea);
        }

        public Idea GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var idea = this.ideas.GetById(intId);
            return idea;
        }

        public Idea GetById(int id)
        {
            var idea = this.ideas.GetById(id);
            return idea;
        }

        public void SaveChanges()
        {
           this.ideas.Save();
        }

        public void Update(Idea idea)
        {
            throw new NotImplementedException();
        }
    }
}
