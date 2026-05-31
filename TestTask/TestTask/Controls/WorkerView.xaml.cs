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
  /// Логика взаимодействия для WorkerView.xaml
  /// </summary>
  public partial class WorkerView : UserControl
  {
    public WorkerView()
    {
      InitializeComponent();
    }

    private void NewRequest_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {

    }

    private void ViewRequestsHistory_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      var window = new ViewRequestsHistoryWindow();

      window.Owner = Window.GetWindow(this);

      window.ShowDialog();
    }

    private void BackToMainMenu_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
      mainWindow.Content = new SelectUserEntry();
    }
  }
}
