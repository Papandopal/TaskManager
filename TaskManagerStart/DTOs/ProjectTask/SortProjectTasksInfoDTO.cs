using UseCase.GeneralServices.Enums;

namespace TaskManagerStart.DTOs.ProjectTask
{
    public class SortProjectTasksInfoDTO
    {
        public string PropertyName { get; init; } = string.Empty;
        public SortMode SortMode { get; init; }
    }
}
