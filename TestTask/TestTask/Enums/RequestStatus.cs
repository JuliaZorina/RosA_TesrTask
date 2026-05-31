using System.ComponentModel;

namespace TestTask.Enums
{
  public enum RequestStatus
  {
    [Description("Создана")]
    Created,

    [Description("В работе")]
    InProgress,

    [Description("Завершена")]
    Completed,

    [Description("Отклонена")]
    Rejected
  }
}
