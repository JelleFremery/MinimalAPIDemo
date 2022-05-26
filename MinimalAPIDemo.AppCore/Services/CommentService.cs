using MinimalAPIDemo.AppCore.Entities;
using MinimalAPIDemo.AppCore.Models;

namespace MinimalAPIDemo.AppCore.Services;

public class CommentService : ICommentService
{
    protected IDictionary<int, Comment> Comments { get; set; }

    protected int NextId { get; set; }

    public CommentService()
    {
        Comments = new Dictionary<int, Comment>();
        NextId = Comments.Count + 1;
    }

    public Comment Create(CreateComment createComment)
    {
        var comment = new Comment
        {
            Id = NextId,
            PostId = createComment.BlogEntryId,
            Message = createComment.Message,
            Created = DateTime.Now
        };

        Comments.Add(NextId, comment);
        NextId++;

        return comment;
    }

    public IList<Comment> ReadAllByBlogEntry(int postId)
    {
        return Comments.Values.Where(p => p.PostId == postId).ToList();
    }
}
