

using ProjectEditor.Domain.Entities.SharedKarnel;

namespace ProjectEditor.Domain.Entities
{
    public sealed class Workers
    {
        private readonly Action<object, string> lazyLoader;
        private Workers(Action<object, string> lazyLoader) => this.lazyLoader = lazyLoader;
        private ProjectWorker _projectWorker;
        private List<Projects> _projects = new List<Projects>();

        public Workers(int id, string workerName, string workerSurname,
            string workerPatronymic, string workerEmail, string workerRole)
        {
            Id = id;
            WorkerName = workerName;
            WorkerSurname = workerSurname;
            WorkerPatronymic = workerPatronymic;
            WorkerEmail = workerEmail;
            WorkerRole = workerRole;
        }

        protected Workers()
        { }

        public int Id { get; protected set; }
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

        public ICollection<Projects> Projects => lazyLoader.Load(this, ref _projects).AsReadOnly();


    }
}
