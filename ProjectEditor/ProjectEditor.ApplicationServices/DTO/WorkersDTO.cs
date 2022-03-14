using ProjectEditor.Domain.Entities;

namespace ProjectEditor.ApplicationServices.DTO
{
    public sealed class WorkersDTO
    {
        public int Id { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }
        public string WorkerPatronymic { get; set; }
        public string WorkerEmail { get; set; }
        public string WorkerRole { get; set; }
        public ProjectWorkerDTO ProjectWorker { get; set; }
        public ProjectsDTO Projects { get; set; }
    }
}
