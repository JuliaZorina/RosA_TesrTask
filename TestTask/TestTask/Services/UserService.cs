using System;
using System.Collections.Generic;
using System.Text;
using TestTask.DB;
using TestTask.Entity;

namespace TestTask.Services
{
  public class UserService
  {
    private readonly ApplicationDbContext _db;

    public UserService(ApplicationDbContext db)
    {
      _db = db;
    }

    public UserEntity GetUserById(Guid userId)
    {
      return _db.Users.FirstOrDefault(u => u.Id.Equals(userId));
    }

    public UserEntity GetUserByName(string userName)
    {
      return _db.Users.FirstOrDefault(u => u.Name.Equals(userName));
    }

    public List<UserEntity> GetAllUsers()
    {
      return _db.Users.ToList();
    }

    public void AddUser(UserEntity user)
    {
      if (user == null)
      {
        throw new ArgumentNullException(nameof(user));
      }

      if (_db.Users.Contains(user))
      {
        throw new ArgumentException($"Пользователь с id {user.Id} уже существует.");
      }

      _db.Users.Add(user);
      _db.SaveChanges();
    }
  }
}
