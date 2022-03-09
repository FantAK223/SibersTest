using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEditor.Domain.Entities.SharedKarnel
{
    public sealed class ProjectWorker
    {
        private readonly Action<object, string> lazyLoader;
        private ProjectWorker(Action<object, string> lazyLoader) => this.lazyLoader = lazyLoader;

        private Projects _projects;
        private Workers _workers;

        public ProjectWorker(Guid id, Projects projects, Workers workers)
        {
            Id = id;
            Projects = projects;
            Workers = workers;
        }

        public Guid Id { get; protected set; }

        public Projects Projects
        {
            get => lazyLoader.Load(this, ref _projects);
            protected set => _projects = value;
        }

        public Workers Workers
        {
            get => lazyLoader.Load(this, ref _workers);
            protected set => _workers = value;
        }

    }
}
