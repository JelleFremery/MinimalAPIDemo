using MinimalAPIDemo.AppCore.Models;
using MinimalAPIDemo.AppCore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IBlogEntryService, BlogEntryService>();
builder.Services.AddSingleton<ICommentService, CommentService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Post API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();


app.MapGet("api/comment/{blogEntryId}", (IBlogEntryService blogEntryService, ICommentService commentService, int blogEntryId) =>
{
    var blogEntry = blogEntryService.ReadById(blogEntryId);

    if (blogEntry == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(commentService.ReadAllByBlogEntry(blogEntryId));
});

app.MapPost("api/comment", (IBlogEntryService blogEntryService, ICommentService commentService, CreateComment createComment) =>
{
    var blogEntry = blogEntryService.ReadById(createComment.BlogEntryId);

    if (blogEntry == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(commentService.Create(createComment));
});

app.MapGet("api/entry", (IBlogEntryService blogEntryService) =>
{
    return blogEntryService.ReadAll();
});

app.MapGet("api/entry/{slug}", (IBlogEntryService blogEntryService, string slug) =>
{
    var blogEntry = blogEntryService.ReadBySlug(slug);

    if (blogEntry == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(blogEntry);
});

app.Run();
