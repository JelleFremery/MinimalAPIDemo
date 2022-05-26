using MinimalAPIDemo.AppCore.Models;
using MinimalAPIDemo.AppCore.Services;

namespace MinimalAPIDemo.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API V1");
                c.RoutePrefix = string.Empty;
            });
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        return app;
    }

    public static WebApplication MapCommentApi(this WebApplication app)
    {
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
        return app;
    }

    public static WebApplication MapBlogEntryApi(this WebApplication app)
    {
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

        return app;
    }
}
