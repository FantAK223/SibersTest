

using ProjectEditor.Domain.Entities.SharedKarnel;

namespace ProjectEditor.Domain.Entities
{
    public sealed class Workers
    {
        private readonly Action<object, string> lazyLoader;
        private Workers(Action<object, string> lazyLoader) => this.lazyLoader = lazyLoader;
        private ProjectWorker _projectWorker;
        private Projects _projects;

        public Workers(Guid id, string workerName, string workerSurname,
            string workerPatronymic, string workerEmail, string workerRole, ProjectWorker projectWorker)
        {
            Id = id;
            WorkerName = workerName;
            WorkerSurname = workerSurname;
            WorkerPatronymic = workerPatronymic;
            WorkerEmail = workerEmail;
            WorkerRole = workerRole;
            ProjectWorker = projectWorker;
        }

        protected Workers()
        { }

        public Guid Id { get; protected set; }
        public string WorkerName { get; protected set; }
        public string WorkerSurname { get; protected set; }
        public string WorkerPatronymic { get; protected set; }
        public string WorkerEmail { get; protected set; }
        public string WorkerRole { get; protected set; }

        public ProjectWorker ProjectWorker
        {
            get => lazyLoader.Load(this, ref _projectWorker);
            protected set => _projectWorker = value;
        }

        public Projects Projects
        {
            get => lazyLoader.Load(this, ref _projects);
            protected set => _projects = value;
        }

    }
}
