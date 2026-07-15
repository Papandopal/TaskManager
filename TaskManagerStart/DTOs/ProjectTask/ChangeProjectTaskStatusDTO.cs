using Domain.Enums;

namespace TaskManagerStart.DTOs.ProjectTask
{
    public class ChangeProjectTaskStatusDTO
    {
        public Guid Id { get; init; }
        public ProjectTaskStatus Status { get; init; }
    }
}
