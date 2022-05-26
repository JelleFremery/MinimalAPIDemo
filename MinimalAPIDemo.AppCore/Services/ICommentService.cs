using MinimalAPIDemo.AppCore.Entities;
using MinimalAPIDemo.AppCore.Models;

namespace MinimalAPIDemo.AppCore.Services;

public interface ICommentService
{
    IList<Comment> ReadAllByBlogEntry(int postId);

    Comment Create(CreateComment createComment);
}
