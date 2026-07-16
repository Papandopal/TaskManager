using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using UseCase.Database;
using UseCase.ProjectTaskServices.Services.DTOs;

namespace UseCase.ProjectTaskServices.Services
{
    public class ProjectTaskService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateProjectTaskUseCaseDTO> updateValidator,
        IValidator<ChangeProjectTaskStatusUseCaseDTO> changeStatusValidator, IValidator<CreateProjectTaskUseCaseDTO> createValidator,
        IValidator<DeleteProjectTaskUseCaseDTO> deleteValidator) : IProjectTaskService
    {
        public void Create(CreateProjectTaskUseCaseDTO createProjectTaskUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            createValidator.ValidateAndThrow(createProjectTaskUseCaseDTO);

            var projectTask = mapper.Map<ProjectTask>(createProjectTaskUseCaseDTO);

            unitOfWork.ProjectTaskRepository.Add(projectTask); 

            unitOfWork.Commit();
        }

        public void Update(UpdateProjectTaskUseCaseDTO updateProjectTaskUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            var projectTask = unitOfWork.ProjectTaskRepository.GetById(updateProjectTaskUseCaseDTO.Id);
            var project = unitOfWork.ProjectRepository.GetById(projectTask.ProjectId);

            updateValidator.ValidateAndThrow(updateProjectTaskUseCaseDTO);

            mapper.Map(updateProjectTaskUseCaseDTO, projectTask);

            unitOfWork.ProjectTaskRepository.Update(projectTask);

            unitOfWork.Commit();
        }

        public void ChangeStatus(ChangeProjectTaskStatusUseCaseDTO changeProjectTaskStatusUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            var projectTask = unitOfWork.ProjectTaskRepository.GetById(changeProjectTaskStatusUseCaseDTO.Id);
            var project = unitOfWork.ProjectRepository.GetById(projectTask.ProjectId);

            changeStatusValidator.ValidateAndThrow(changeProjectTaskStatusUseCaseDTO);  

            mapper.Map(changeProjectTaskStatusUseCaseDTO, projectTask);

            unitOfWork.ProjectTaskRepository.Update(projectTask);

            unitOfWork.Commit();
        }

        public void Delete(DeleteProjectTaskUseCaseDTO deleteProjectTaskUseCaseDTO)
        {
            unitOfWork.StartTransaction();

            var projectTask = unitOfWork.ProjectTaskRepository.GetById(deleteProjectTaskUseCaseDTO.Id);
            var project = unitOfWork.ProjectRepository.GetById(projectTask.ProjectId);

            deleteValidator.ValidateAndThrow(deleteProjectTaskUseCaseDTO);

            projectTask.Delete();

            unitOfWork.ProjectTaskRepository.Update(projectTask);

            unitOfWork.Commit();
        }

        public ProjectTask GetById(Guid id)
        {
            unitOfWork.StartTransaction();

            var projectTask = unitOfWork.ProjectTaskRepository.GetById(id);

            unitOfWork.Commit();

            return projectTask;
        }

        public IEnumerable<ProjectTask> GetAll()
        {
            unitOfWork.StartTransaction();

            var projectTasks = unitOfWork.ProjectTaskRepository.GetAll();

            unitOfWork.Commit();

            return projectTasks;
        }

        public IEnumerable<ProjectTask> GetByProjectId(Guid projectId)
        {
            unitOfWork.StartTransaction();

            var projectTasks = unitOfWork.ProjectTaskRepository.GetByProjectId(projectId);

            unitOfWork.Commit();

            return projectTasks;
        }
    }
}
