using UseCase.GeneralServices.Enums;

namespace TaskManagerStart.DTOs.ProjectTask
{
    public class FilterProjectTasksInfoDTO
    {
        public string PropertyName { get; init; } = string.Empty;
        public string PropertyValue { get; init; } = string.Empty;
        public FilterComparer FilterComparer { get; init; }
    }
}
