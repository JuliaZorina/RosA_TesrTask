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
using TestTask.Entity;

namespace TestTask.Controls
{
  /// <summary>
  /// Логика взаимодействия для EditRequestStatusWindow.xaml
  /// </summary>
  public partial class EditRequestStatusWindow : Window
  {
    public EditRequestStatusWindow(Request request)
    {
      InitializeComponent();

      //this.RequestStatusEditor.UserName.Text = request.User.Name;
      this.RequestStatusEditor.RequsеstsNumber.Text = request.NumberOfRequests.ToString();
      this.RequestStatusEditor.RequstType.Text = request.RequestTypeName.ToString();
      this.RequestStatusEditor.RequsеstReason.Text = request.Reason;
      this.RequestStatusEditor.RequestId = request.Id;

      this.RequestStatusEditor.RequsеstSatus.ItemsSource = Enum.GetValues<Enums.RequestStatus>();
      RequestStatusEditor.RequsеstSatus.SelectedItem = request.Status;
    }
  }
}
