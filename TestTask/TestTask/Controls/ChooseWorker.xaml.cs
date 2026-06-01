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
using TestTask.Enums;

namespace TestTask.Controls
{
  /// <summary>
  /// Логика взаимодействия для ChooseWorker.xaml
  /// </summary>
  public partial class ChooseWorker : Window
  {
    public ChooseWorker()
    {
      InitializeComponent();
      LoadUsers();
    }

    private void LoadUsers()
    {
      var db = new ApplicationDbContext();
      var users = db.Users
          .Where(u => u.Role == UserRole.Worker)
          .ToList();

      foreach (var user in users)
      {
        var button = new Button
        {
          Content = user.Name,
          Tag = user,
          Margin = new Thickness(0, 0, 0, 10),
          Height = 40
        };

        button.Click += UserButton_Click;

        UsersPanel.Children.Add(button);
      }
    }

    private void UserButton_Click(object sender, RoutedEventArgs e)
    {
      var button = sender as Button;
      var user = (UserEntity)button.Tag;
      // Handle user selection
      this.Content = new WorkerView(user);
    }
  }
}
