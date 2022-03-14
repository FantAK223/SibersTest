using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectEditor.ApplicationServices.DTO;
using ProjectEditor.Domain.Entities;
using ProjectEditor.Domain.Entities.SharedKarnel;
using ProjectEditor.DomainEntityFramework;

namespace ProjectEditor.ApplicationServices.Services
{
    public sealed class ProjectsService
    {
        private readonly ProjectEditorDbContext context;
        private readonly IMapper mapper;

        public ProjectsService(ProjectEditorDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // Сервис для получения данных о проектах
        public IQueryable<ProjectsDTO> Get() => mapper.ProjectTo<ProjectsDTO>(context.Set<Projects>());


        // Сервис для добавления нового проекта
        public async Task SaveAsync(ProjectsDTO dto)
        {

            context.Set<Projects>().Add(mapper.Map<Projects>(dto));
            await context.SaveChangesAsync();
        }

        // Сервис для удаления всех проектов
        public async Task Delete()
        {
            context.Set<Projects>().RemoveRange(context.Set<Projects>());
            context.SaveChanges();
        }
    }
}
