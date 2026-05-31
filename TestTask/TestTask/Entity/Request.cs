using TestTask.Enums;

namespace TestTask.Entity
{
  public class Request
  {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public RequestType RequestTypeName { get; set; }
    public int NumberOfRequests { get; set; }
    public string Reason { get; set; }
    public RequestStatus Status { get; set; }
    public UserEntity User { get; set; } = null!;
  }
}
