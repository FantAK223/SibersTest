using ProjectEditor.Domain.Entities.SharedKarnel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEditor.Domain.Entities
{
    public sealed class Projects
    {
        private readonly Action<object, string> lazyLoader;
        private Projects(Action<object, string> lazyLoader) => this.lazyLoader = lazyLoader;
        private ProjectWorker _projectWorker;
        private List<Workers> _workers = new List<Workers>();

        public Projects(int id,string nameProject, string clientCompanyName, string creatorCompanyName,
            DateTime startProjectDate, DateTime endProjectDate, int projectPriority, int idProjectDirector)
        {
            Id = id;
            NameProject = nameProject;
            ClientCompanyName = clientCompanyName;
            CreatorCompanyName = creatorCompanyName;
            StartProjectDate = startProjectDate;
            EndProjectDate = endProjectDate;
            ProjectPriority = projectPriority;
            IdProjectDirector = idProjectDirector;
        }

        protected Projects()
        { }

        public int Id { get; protected set; }
        public string NameProject { get; protected set; }
        public string ClientCompanyName { get; protected set; }
        public string CreatorCompanyName { get; protected set; }
        public DateTime StartProjectDate { get; protected set; }
        public DateTime EndProjectDate { get; protected set; }
        public int ProjectPriority { get; protected set; }
        public int IdProjectDirector { get; protected set; }

        public ProjectWorker ProjectWorker
        {
            get => lazyLoader.Load(this, ref _projectWorker);
            protected set => _projectWorker = value;
        }

        public ICollection<Workers> Workers => lazyLoader.Load(this, ref _workers).AsReadOnly();


    }
}
