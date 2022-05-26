namespace MinimalAPIDemo.AppCore.Entities;

public class Comment
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public string Message { get; set; } = string.Empty;

    public DateTime Created { get; set; }
}
