using MinimalAPIDemo.AppCore.Entities;
using MinimalAPIDemo.AppCore.Models;
using MinimalAPIDemo.AppCore.Services;

namespace MinimalAPIDemo.Mvc.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly IBlogEntryService _blogEntryService;
    private readonly ICommentService _commentService;

    public CommentController(IBlogEntryService blogEntryService,
        ICommentService commentService)
    {
        _blogEntryService = blogEntryService;
        _commentService = commentService;
    }

    [HttpGet("{blogEntryId}")]
    public ActionResult<IEnumerable<BlogEntry>> GetAllByBlogEntry(int blogEntryId)
    {
        var blogEntry = _blogEntryService.ReadById(blogEntryId);

        if (blogEntry == null)
        {
            return new NotFoundResult();
        }

        return Ok(_commentService.ReadAllByBlogEntry(blogEntryId));
    }

    [HttpPost]
    public ActionResult<BlogEntry> Post(CreateComment createComment)
    {
        var blogEntry = _blogEntryService.ReadById(createComment.BlogEntryId);

        if (blogEntry == null)
        {
            return new NotFoundResult();
        }

        return Ok(_commentService.Create(createComment));
    }
}