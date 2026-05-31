namespace TestTask.Entity
{
  public class UserEntity
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public ICollection<Request> Requests { get; set; } = new List<Request>();

  }
}
