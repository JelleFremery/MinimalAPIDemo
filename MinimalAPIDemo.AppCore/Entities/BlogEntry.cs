namespace MinimalAPIDemo.AppCore.Entities;

public class BlogEntry
{
    public int Id { get; set; }

    public string Title { get; set; } = "Untitled";

    public string Article { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public DateTime Published { get; set; } = DateTime.Now;
}
