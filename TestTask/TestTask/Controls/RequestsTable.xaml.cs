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
using TestTask.DB;
using TestTask.Entity;
using TestTask.Services;

namespace TestTask.Controls
{
  /// <summary>
  /// Логика взаимодействия для RequestsTable.xaml
  /// </summary>
  public partial class RequestsTable : UserControl
  {
    public RequestsTable()
    {
      InitializeComponent();
    }

    private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      var button = (Button)sender;

      var request = (Request)button.CommandParameter;

      var db = new ApplicationDbContext();
      var requestService = new RequestService(db);
      var foundRequest = requestService.GetRequestById(request.Id);
      if (foundRequest == null)
      {
        MessageBox.Show("Заявка не найдена.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      var userService = new UserService(db);
      var foundUser = userService.GetUserById(foundRequest.UserId);
      if (foundUser == null)
      { 
        MessageBox.Show("Владелец заявки не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      var window = new EditRequestStatusWindow(foundRequest, foundUser.Name);
      window.Owner = Window.GetWindow(this);
      var result = window.ShowDialog();

      if (result == true)
      {
        LoadRequests();
      }
    }

    private void LoadRequests()
    {
      var db = new ApplicationDbContext();
      var requestService = new RequestService(db);
      var requests = requestService.GetAllRequests();
      this.ReuestsGrid.ItemsSource = requests;
    }
  }
}
