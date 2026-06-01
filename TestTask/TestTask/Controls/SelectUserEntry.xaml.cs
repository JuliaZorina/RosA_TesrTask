using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
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
      var window = new ChooseWorker();
      window.Owner = Window.GetWindow(this);
      window.Show();
    }

    private void EnterAsAccountant_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      var accontantWindow = new AccountantRequestTableView();
      accontantWindow.Owner = Window.GetWindow(this);
      accontantWindow.Show();
    }
  }
}
