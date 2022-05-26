using MinimalAPIDemo.AppCore.Entities;

namespace MinimalAPIDemo.AppCore.Services
{
    public interface IBlogEntryService
    {
        IList<BlogEntry> ReadAll();

        BlogEntry? ReadById(int id);
        BlogEntry? ReadBySlug(string slug);
    }
}
