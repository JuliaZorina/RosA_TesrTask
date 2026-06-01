using System;
using System.Collections.Generic;
using System.Text;
using TestTask.Entity;
using TestTask.Enums;

namespace TestTask.DB
{
  public class DataSeeder
  {
    public static void Seed(ApplicationDbContext db)
    {
      if (db.Users.Any())
        return;

      var employee1 = new UserEntity
      {
        Id = Guid.NewGuid(),
        Name = "Иванов И.И.",
        Role = UserRole.Worker
      };

      var employee2 = new UserEntity
      {
        Id = Guid.NewGuid(),
        Name = "Петров П.П.",
        Role = UserRole.Worker
      };

      var accountant = new UserEntity
      {
        Id = Guid.NewGuid(),
        Name = "Сидорова А.А.",
        Role = UserRole.Accountant
      };

      db.Users.AddRange(employee1, employee2, accountant);

      var requests = new List<Request>
        {
            new()
            {
                Id = Guid.NewGuid(),
                UserId = employee1.Id,
                User = employee1,
                RequestTypeName = RequestType.Salary,
                NumberOfRequests = 2,
                Reason = "Для банка",
                Status = RequestStatus.Created,
                CreatedAt = DateTime.Now.AddDays(-10)
            },

            new()
            {
                Id = Guid.NewGuid(),
                UserId = employee1.Id,
                User = employee1,
                RequestTypeName = RequestType.Employment,
                NumberOfRequests = 1,
                Reason = "Для визы",
                Status = RequestStatus.Completed,
                CreatedAt = DateTime.Now.AddDays(-8)
            },

            new()
            {
                Id = Guid.NewGuid(),
                UserId = employee2.Id,
                User = employee2,
                RequestTypeName = RequestType.Salary,
                NumberOfRequests = 3,
                Reason = "Для ипотеки",
                Status = RequestStatus.InProgress,
                CreatedAt = DateTime.Now.AddDays(-6)
            },

            new()
            {
                Id = Guid.NewGuid(),
                UserId = employee2.Id,
                User = employee2,
                RequestTypeName = RequestType.NDFL2,
                NumberOfRequests = 1,
                Reason = "По месту требования",
                Status = RequestStatus.Created,
                CreatedAt = DateTime.Now.AddDays(-3)
            },

            new()
            {
                Id = Guid.NewGuid(),
                UserId = employee2.Id,
                User = employee2,
                RequestTypeName = RequestType.Employment,
                NumberOfRequests = 2,
                Reason = "Личные нужды",
                Status = RequestStatus.Completed,
                CreatedAt = DateTime.Now.AddDays(-1)
            }
        };

      db.Requests.AddRange(requests);

      db.SaveChanges();
    }
  }
}
