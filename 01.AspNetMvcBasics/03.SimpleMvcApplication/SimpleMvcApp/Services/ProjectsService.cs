namespace SimpleMvcApp.Services
{
    using System.Collections.Generic;

    using ViewModels;

    public class ProjectsService
    {

        private readonly IList<ProjectViewModel> projects = new List<ProjectViewModel>
        {
            new ProjectViewModel { Id = 0, Title = "Project 1", Description = "Project 1 Description", Value = 45.22M },
            new ProjectViewModel { Id = 1, Title = "Project 2", Description = "Project 2 Description", Value = 37.15M },
            new ProjectViewModel { Id = 2, Title = "Project 3", Description = "Project 3 Description", Value = 80.4M }
        };

        public IList<ProjectViewModel> All()
        {
            return this.projects;
        }
    }
}