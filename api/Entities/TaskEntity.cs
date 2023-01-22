using PointS.Api.Core.Entities;

namespace PointS.Api.Entity;

public enum TaskStatus
{
    Doing = 1,
    Done = 2
}

public class TaskEntity : EntityBase
{
    public static int TITLE_MAX_LENGTH = 100;
    public static int DESCRIPTION_MAX_LENGTH = 1000;

    public string Title { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; } = TaskStatus.Doing;
}