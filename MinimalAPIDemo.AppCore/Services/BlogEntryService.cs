using MinimalAPIDemo.AppCore.Entities;

namespace MinimalAPIDemo.AppCore.Services;

public class BlogEntryService : IBlogEntryService
{
    protected IDictionary<int, BlogEntry> BlogEntries { get; set; }

    protected int NextId { get; set; }

    public BlogEntryService()
    {
        BlogEntries = new Dictionary<int, BlogEntry>
        {
            {
                1,
                new BlogEntry
                {
                    Id = 1,
                    Title = "Lorem Ipsum",
                    Article = "We have hired a new developer. He's named Lorem Ipsum and has years of experience filling websites.",
                    Slug = "new-developer-hired",
                    Published = new DateTime(2022, 4, 21)
                }
            },

            {
                2,
                new BlogEntry
                {
                    Id = 2,
                    Title = ".NET 6 released",
                    Article = "Microsoft has released .NET 6 and C#10, with new features like global usings and minimal API's.",
                    Slug = "net-6-released",
                    Published = new DateTime(2022, 5, 21)
                }
            }
        };

        NextId = BlogEntries.Count + 1;
    }

    public IList<BlogEntry> ReadAll()
    {
        return BlogEntries.Values.ToList();
    }


    public BlogEntry? ReadById(int id)
    {
        if (!BlogEntries.ContainsKey(id))
        {
            return null;
        }

        return BlogEntries[id];
    }

    public BlogEntry? ReadBySlug(string slug)
    {
        return BlogEntries.Values.FirstOrDefault(be => be.Slug == slug);
    }
}