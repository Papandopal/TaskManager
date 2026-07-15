using UseCase.GeneralServices.Enums;

namespace TaskManagerStart.DTOs.ProjectTask
{
    public class FindProjectTasksInfoDTO
    {
        public string PropertyName { get; init; } = string.Empty;
        public string PropertyValue { get; init; } = string.Empty;
        public FindFlags FindFlags { get; init; }
    }
}
