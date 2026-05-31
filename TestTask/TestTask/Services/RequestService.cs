using System;
using System.Collections.Generic;
using System.Text;
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
      return _db.Requests.ToList();
    }

    public List<Request> GetAllRequestsByUserId(Guid userId)
    {
      return _db.Requests.Where(r => r.UserId.Equals(userId)).ToList();
    }

    public List<Request> GetAllRequestsByUserName(string userName)
    {
      return _db.Requests.Where(r => r.User.Name.Equals(userName)).ToList();
    }

    public async Task EditRequestStatus(Guid requestId, RequestStatus newStatus)
    {
      var foundRequest = _db.Requests.Find(requestId);
      if (foundRequest != null)
      {
        foundRequest?.Status = newStatus;
        _db.Update(foundRequest);
        await _db.SaveChangesAsync();
      }
      else
      {
        throw new ArgumentException($"Запрос с id {requestId} не найден.");
      }
    }

    public void CreateNewRequest(Request request)
    {
      if (request == null)
      {
        throw new ArgumentNullException(nameof(request));
      }

      if (_db.Requests.Contains(request))
      {
        throw new ArgumentException($"Запрос с id {request.Id} уже существует.");
      }

      _db.Requests.Add(request);
      _db.SaveChanges();
    }
  }
}
