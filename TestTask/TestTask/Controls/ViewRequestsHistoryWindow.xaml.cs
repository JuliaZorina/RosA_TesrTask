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
  /// Логика взаимодействия для ViewRequestsHistoryWindow.xaml
  /// </summary>
  public partial class ViewRequestsHistoryWindow : Window
  {
    public ViewRequestsHistoryWindow()
    {
      InitializeComponent();
    }
    public void SeDataForCurrentUser(UserEntity user)
    {
      ShowData(user);
    }

    private void ShowData(UserEntity user)
    {
      this.Table.RequestActions.Visibility = Visibility.Collapsed;
      this.Table.RequestWorker.Visibility = Visibility.Collapsed;
      this.Table.TableName.Text = "История заявок";

      var db = new ApplicationDbContext();
      var requestService = new RequestService(db);
      var requests = requestService.GetAllRequestsByUserId(user.Id);

      if (requests != null)
      {
        this.Table.ReuestsGrid.ItemsSource = requests;
      }
    }
  }
}
