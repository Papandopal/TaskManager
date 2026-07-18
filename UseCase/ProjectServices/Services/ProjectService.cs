using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using UseCase.Database;
using UseCase.ProjectServices.Services.DTOs;

namespace UseCase.ProjectServices.Services
{
    public class ProjectService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateProjectUseCaseDTO> createValidator,
        IValidator<ChangeProjectStatusUseCaseDTO> changeStatusValidator, IValidator<UpdateProjectUseCaseDTO> updateValidator,
        IValidator<DeleteProjectUseCaseDTO> deleteValidator) : IProjectService
    {
        public void Create(CreateProjectUseCaseDTO createProjectUseCaseDTO)
        {
            var project = mapper.Map<Project>(createProjectUseCaseDTO);
            unitOfWork.StartTransaction();

            createValidator.ValidateAndThrow(createProjectUseCaseDTO);

            unitOfWork.ProjectRepository.Add(project);

            unitOfWork.Commit();
        }

        public void Update(UpdateProjectUseCaseDTO updateProjectUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            var project = unitOfWork.ProjectRepository.GetById(updateProjectUseCaseDTO.Id);

            updateValidator.ValidateAndThrow(updateProjectUseCaseDTO);

            mapper.Map(updateProjectUseCaseDTO, project);

            unitOfWork.ProjectRepository.Update(project);

            unitOfWork.Commit();
        }

        public void ChangeStatus(ChangeProjectStatusUseCaseDTO changeStatusUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            var project = unitOfWork.ProjectRepository.GetById(changeStatusUseCaseDTO.Id);

            changeStatusValidator.ValidateAndThrow(changeStatusUseCaseDTO);

            mapper.Map(changeStatusUseCaseDTO, project);

            unitOfWork.ProjectRepository.Update(project);

            unitOfWork.Commit();
        }

        public void Delete(DeleteProjectUseCaseDTO deleteProjectUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            var project = unitOfWork.ProjectRepository.GetById(deleteProjectUseCaseDTO.Id);

            deleteValidator.ValidateAndThrow(deleteProjectUseCaseDTO);

            project.Delete();

            unitOfWork.ProjectRepository.Update(project);

            unitOfWork.Commit();
        }

        public Project GetById(Guid id)
        {
            unitOfWork.StartTransaction();

            var project = unitOfWork.ProjectRepository.GetById(id);

            unitOfWork.Commit();

            return project;
        }

        public IQueryable<Project> GetAll()
        {
            unitOfWork.StartTransaction();

            var projects = unitOfWork.ProjectRepository.GetAll();

            unitOfWork.Commit();

            return projects;
        }
    }
}
