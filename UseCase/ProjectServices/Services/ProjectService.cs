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

        public void Update(UpdateProjectUseCaseDTO updateProjectUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            var project = unitOfWork.ProjectRepository.GetById(updateProjectUseCaseDTO.Id);

            if (project.OwnerId != updateProjectUseCaseDTO.UpdaterId) throw new Exception("Access denied");

            mapper.Map(updateProjectUseCaseDTO, project);

            unitOfWork.ProjectRepository.Update(project);

            unitOfWork.Commit();
        }

        public void Delete(DeleteProjectUseCaseDTO deleteProjectUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            var project = unitOfWork.ProjectRepository.GetById(deleteProjectUseCaseDTO.Id);

            if (project.OwnerId != deleteProjectUseCaseDTO.DeleterId) throw new Exception("Access denied");

            unitOfWork.ProjectRepository.Delete(deleteProjectUseCaseDTO.Id);

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
