using AutoMapper;
using ProjectEditor.ApplicationServices.DTO;
using ProjectEditor.Domain.Entities;
using ProjectEditor.DomainEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEditor.ApplicationServices.Services
{
    public sealed class WorkersService
    {
        private readonly ProjectEditorDbContext context;
        private readonly IMapper mapper;

        public WorkersService(ProjectEditorDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // Сервис для получения данных о работниках
        public IQueryable<WorkersDTO> Get() => mapper.ProjectTo<WorkersDTO>(context.Set<Workers>());

        // Сервис для добавления нового работника
        public async Task SaveAsync(WorkersDTO dto)
        {

            context.Set<Workers>().Add(mapper.Map<Workers>(dto));
            await context.SaveChangesAsync();
        }

        // Сервис для удаления всех работников
        public async Task Delete()
        {
            context.Set<Workers>().RemoveRange(context.Set<Workers>());
            context.SaveChanges();
        }
    }
}
