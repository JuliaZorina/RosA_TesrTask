using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestTask.Enums
{
  public enum RequestType
  {
    [Description("Справка 2-НДФЛ")]
    NDFL2,
    [Description("Справка о месте работы и стаже")]
    Employment,
    [Description("Справка о среднем заработке")]
    Salary,
    [Description("Справка произвольного типа")]
    Other
  }
}
