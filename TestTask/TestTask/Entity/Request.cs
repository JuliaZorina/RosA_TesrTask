namespace TestTask.Entity
{
  public class Request
  {
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedAt { get; set; }
    public string RequestTypeName { get; set; }
    public int NumberOfRequests { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; }
  }
}
