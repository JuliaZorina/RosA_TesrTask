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
using TestTask.Entity;

namespace TestTask.Controls
{
  /// <summary>
  /// Логика взаимодействия для WorkerView.xaml
  /// </summary>
  public partial class WorkerView : UserControl
  {
    private readonly UserEntity _currentUser;


    public WorkerView(UserEntity currentUser)
    {
      InitializeComponent();
      _currentUser = currentUser;
    }

    private void NewRequest_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      var window = new NewRequestWindow(_currentUser);

      window.Owner = Window.GetWindow(this);

      window.ShowDialog();
    }

    private void ViewRequestsHistory_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      var window = new ViewRequestsHistoryWindow();
      window.SeDataForCurrentUser(_currentUser);

      window.Owner = Window.GetWindow(this);

      window.ShowDialog();
    }

    private void BackToMainMenu_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      var window = Window.GetWindow(this);
      window.Close();
    }
  }
}
