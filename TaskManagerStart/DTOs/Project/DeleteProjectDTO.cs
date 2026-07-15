namespace TaskManagerStart.DTOs.Project
{
    public class DeleteProjectDTO
    {
        public Guid Id { get; init; }
        public Guid DeleterId { get; set; }
    }
}
