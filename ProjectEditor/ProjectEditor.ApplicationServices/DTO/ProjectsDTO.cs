namespace ProjectEditor.ApplicationServices.DTO
{
    public sealed class ProjectsDTO
    {
        public int Id { get;set; }
        public string NameProject { get; set; }
        public string ClientCompanyName { get; set; }
        public string CreatorCompanyName { get; set; }
        public DateTime StartProjectDate { get; set; }
        public DateTime EndProjectDate { get; set; }
        public int ProjectPriority { get; set; }
        public int IdProjectDirector { get; set; }
        public WorkersDTO Workers { get; set; }
    }
}
