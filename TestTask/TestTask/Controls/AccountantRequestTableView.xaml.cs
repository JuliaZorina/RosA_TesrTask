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
using System.Windows.Shapes;
using TestTask.DB;
using TestTask.Entity;
using TestTask.Services;

namespace TestTask.Controls
{
  /// <summary>
  /// Логика взаимодействия для AccountantRequestTableView.xaml
  /// </summary>
  public partial class AccountantRequestTableView : Window
  {
    public AccountantRequestTableView()
    {
      InitializeComponent(); var db = new ApplicationDbContext();
      var requestService = new RequestService(db);
      var userService = new UserService(db);
      var requests = requestService.GetAllRequests();

      if (requests != null)
      {
        this.RequestTable.ReuestsGrid.ItemsSource = requests;
      }
    }

    private void Cancel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      this.Close();
    }
  }
}
