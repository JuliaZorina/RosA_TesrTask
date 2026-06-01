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
using TestTask.Enums;
using TestTask.Services;
using static System.Net.Mime.MediaTypeNames;

namespace TestTask.Controls
{
  /// <summary>
  /// Логика взаимодействия для NewRequest.xaml
  /// </summary>
  public partial class NewRequest : UserControl
  {
    internal UserEntity CurrentUser;

    public NewRequest()
    {
      InitializeComponent();
      this.RequestTypeComboBox.ItemsSource = Enum.GetValues<RequestType>()
        .Select(x => new
        {
          Value = x,
          Name = x.GetDescription()
        })
        .ToList();
      this.RequestTypeComboBox.DisplayMemberPath = "Name";
      this.RequestTypeComboBox.SelectedValuePath = "Value";
    }

    private void Send_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      if (string.IsNullOrEmpty(this.RequestsNumberTextBox.Text))
      {
        MessageBox.Show($"Поле 'Количество запросов' не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      var request = new Request();
      request.Id = Guid.NewGuid();
      request.Status = RequestStatus.Created;
      var requestType = (RequestType)this.RequestTypeComboBox.SelectedValue;
      request.RequestTypeName = requestType;
      if (int.TryParse(this.RequestsNumberTextBox.Text, out int number))
      {
        request.NumberOfRequests = number;
      }
      else
      {
        MessageBox.Show($"Поле 'Количество запросов' не может быть строкой, введите число.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }
      request.Reason = new TextRange(
          this.RequestReasonTextBox.Document.ContentStart,
          this.RequestReasonTextBox.Document.ContentEnd
      ).Text;
      request.UserId = CurrentUser.Id;
      //request.User = CurrentUser;

      var db = new ApplicationDbContext();
      var requestService = new RequestService(db);
      requestService.CreateNewRequest(request);
      var window = Window.GetWindow(this);
      window.Close();
    }

    private void Cancel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      var window = Window.GetWindow(this);
      window.Close();
    }
  }
}
