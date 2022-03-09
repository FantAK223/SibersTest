using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEditor.ApplicationServices.DTO
{
    public sealed class ProjectWorkerDTO
    {
        public Guid Id { get; set; }
        public ProjectsDTO Projects { get; set; }
        public WorkersDTO Workers { get; set; }
    }
}
