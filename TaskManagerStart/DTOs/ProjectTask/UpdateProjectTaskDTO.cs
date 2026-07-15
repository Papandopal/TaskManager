namespace TaskManagerStart.DTOs.ProjectTask
{
    public class UpdateProjectTaskDTO
    {
        public Guid Id { get; init; }
        public string? Title { get; init; } = string.Empty;
        public string? Description { get; init; } = string.Empty;
        public DateTime? DueDate { get; init; }
    }
}
