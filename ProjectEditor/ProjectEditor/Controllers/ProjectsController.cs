using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectEditor.ApplicationServices.DTO;
using ProjectEditor.ApplicationServices.Services;

namespace ProjectEditor.Web.Controllers
{
    [ApiController]
    [Route("api/bo/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectsService service;

        public ProjectsController(ProjectsService service) => this.service = service;

        [HttpGet]
        public async Task<IActionResult> ProjectWorkers(int idProject)
        {

            List<ProjectWorkerDTO> view = mapper.Map<List<ProjectWorkerDTO>>(workers);

            ViewBag.IdProject = idProject;

            return View(view);
        }

        // GET: ProjectsController
        [HttpGet]
        public async Task<IActionResult> AddProjectWorker(int idProject)
        {
            if (result == true)
            {
                return RedirectToAction(nameof(ProjectsController.ProjectWorkers), "Project", new { idProject });
            }

            return RedirectToAction(nameof(ProjectsController.AddProjectWorker), "Project", new { idProject });
        }

        [HttpPost("add-project")]
        public async Task<IActionResult> Save(ProjectsDTO dto)
        {
            await service.SaveAsync(dto);
            return Ok(dto);
        }
    }
}
