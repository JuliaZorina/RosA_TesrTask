using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestTask.Controls
{
  /// <summary>
  /// Логика взаимодействия для SelectUserEntry.xaml
  /// </summary>
  public partial class SelectUserEntry : UserControl
  {
    public SelectUserEntry()
    {
      InitializeComponent();
    }

    private void EnterAsWorker_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      this.Content = new WorkerView();
    }
  }
}
