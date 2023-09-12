namespace Urnaus.Shared;

public class Feedback
{
    public int Id { get; set; }
    public string Description { get; set; }

    public Education Education { get; set; }

    public User User { get; set; }
}