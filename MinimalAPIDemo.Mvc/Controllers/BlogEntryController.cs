using MinimalAPIDemo.AppCore.Entities;
using MinimalAPIDemo.AppCore.Services;

namespace MinimalAPIDemo.Mvc.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogEntryController : ControllerBase
{
    private readonly IBlogEntryService _blogEntryService;

    public BlogEntryController(IBlogEntryService blogEntryService)
    {
        _blogEntryService = blogEntryService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BlogEntry>> Get()
    {
        return Ok(_blogEntryService.ReadAll());
    }

    [HttpGet("{slug}")]
    public ActionResult<BlogEntry> Get(string slug)
    {
        var blogEntry = _blogEntryService.ReadBySlug(slug);
        if (blogEntry == null)
        {
            return new NotFoundResult();
        }

        return Ok(blogEntry);
    }
}
