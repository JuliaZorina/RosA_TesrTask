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

namespace TestTask.Controls
{
  /// <summary>
  /// Логика взаимодействия для RequestEditor.xaml
  /// </summary>
  public partial class RequestEditor : UserControl
  {
    public Guid RequestId { get; set; }
    public RequestEditor()
    {
      InitializeComponent();
    }

    private void Cancel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      var window = Window.GetWindow(this);
      window.Close();
    }

    private void Save_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      var status = (RequestStatus)this.RequsеstSatus.SelectedItem;
      var db = new ApplicationDbContext();
      var requestService = new RequestService(db);

      var foundRequest = db.Requests.Find(RequestId);
      if (foundRequest != null)
      {
        foundRequest?.Status = status;
        requestService.EditRequestStatus(foundRequest).ConfigureAwait(true);

        var window = Window.GetWindow(this);

        if (window != null)
        {
          window.DialogResult = true;
        }
      }
      else
      {
        MessageBox.Show($"Запрос с id {RequestId} не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }
    }
  }
}
