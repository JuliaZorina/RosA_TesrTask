using System.ComponentModel;

namespace TestTask.Enums
{
  public enum UserRole
  {
    [Description("Сотрудник")]
    Worker,
    [Description("Бухгалтер")]
    Accountant 
  }
}
