using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TestTask.DB;
using TestTask.Entity;
using TestTask.Enums;

namespace TestTask.Services
{
  public class RequestService
  {
    private readonly ApplicationDbContext _db;

    public RequestService(ApplicationDbContext db)
    {
      _db = db;
    }

    public Request GetRequestById(Guid requestId)
    {
      return _db.Requests.FirstOrDefault(r => r.Id.Equals(requestId));
    }

    public List<Request> GetAllRequests()
    {
      return _db.Requests.Include(r => r.User).ToList();
    }

    public List<Request> GetAllRequestsByUserId(Guid userId)
    {
      return _db.Requests.Where(r => r.UserId.Equals(userId)).ToList();
    }

    public List<Request> GetAllRequestsByUserName(string userName)
    {
      return _db.Requests.Where(r => r.User.Name.Equals(userName)).ToList();
    }

    public async Task EditRequestStatus(Request request)
    {
      _db.Update(request);
      await _db.SaveChangesAsync();
    }

    public void CreateNewRequest(Request request)
    {
      if (request == null)
      {
        MessageBox.Show($"Запрос не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      if (_db.Requests.Contains(request))
      {
        MessageBox.Show($"Запрос с id {request.Id} уже существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      _db.Requests.Add(request);
      _db.SaveChanges();
    }
  }
}
