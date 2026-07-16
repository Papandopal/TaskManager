using Domain.Enums;

namespace TaskManagerStart.DTOs.Project
{
    public class ChangeProjectStatusDTO
    {
        public Guid Id { get; init; }
        public Guid ChangerId { get; init; }
        public ProjectStatus Status { get; set; }
    }
}
