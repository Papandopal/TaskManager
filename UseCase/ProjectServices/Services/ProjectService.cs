using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using UseCase.Database;
using UseCase.ProjectServices.Services.DTOs;

namespace UseCase.ProjectServices.Services
{
    public class ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        public void Create(CreateProjectUseCaseDTO createProjectUseCaseDTO)
        {
            var project = mapper.Map<Project>(createProjectUseCaseDTO);
            unitOfWork.StartTransaction();

            unitOfWork.ProjectRepository.Add(project);

            unitOfWork.Commit();
        }

        public void Update(UpdateProjectUseCaseDTO updateProjectDTO)
        {
            unitOfWork.StartTransaction();
            var project = unitOfWork.ProjectRepository.GetById(updateProjectDTO.Id);

            unitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            unitOfWork.StartTransaction();

            unitOfWork.ProjectRepository.Delete(id);

            unitOfWork.Commit();
        }

        public Project GetById(Guid id)
        {
            unitOfWork.StartTransaction();

            var project = unitOfWork.ProjectRepository.GetById(id);

            unitOfWork.Commit();

            return project;
        }

        public IEnumerable<Project> GetAll()
        {
            unitOfWork.StartTransaction();

            var projects = unitOfWork.ProjectRepository.GetAll();

            unitOfWork.Commit();

            return projects;
        }
    }
}
