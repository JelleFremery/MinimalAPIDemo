namespace MinimalAPIDemo.AppCore.Models;
public class CreateComment
{
    public int BlogEntryId { get; set; }

    public string Message { get; set; } = string.Empty;
}
