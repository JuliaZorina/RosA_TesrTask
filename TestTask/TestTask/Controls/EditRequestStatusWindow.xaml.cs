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
using TestTask.Enums;

namespace TestTask.Controls
{
  /// <summary>
  /// Логика взаимодействия для EditRequestStatusWindow.xaml
  /// </summary>
  public partial class EditRequestStatusWindow : Window
  {
    public EditRequestStatusWindow(Request request, string userName)
    {
      InitializeComponent();

      this.RequestStatusEditor.RequsеstsNumber.Text = request.NumberOfRequests.ToString();
      this.RequestStatusEditor.RequstType.Text = request.RequestType;
      this.RequestStatusEditor.RequsеstReason.Text = request.Reason;
      this.RequestStatusEditor.RequestId = request.Id;
      this.RequestStatusEditor.UserName.Text = userName;
      this.RequestStatusEditor.EditorName.Content = this.RequestStatusEditor.EditorName.Content.ToString()+request.CreatedAt.ToString();

      this.RequestStatusEditor.RequsеstSatus.ItemsSource = Enum.GetValues<RequestStatus>()
        .Select(x => new
        {
          Value = x,
          Name = x.GetDescription()
        })
        .ToList();
      this.RequestStatusEditor.RequsеstSatus.DisplayMemberPath = "Name";
      this.RequestStatusEditor.RequsеstSatus.SelectedValuePath = "Value";
      RequestStatusEditor.RequsеstSatus.SelectedItem = request.StatusName;
    }
  }
}
