using MinimalAPIDemo.AppCore.Services;

namespace MinimalAPIDemo.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IBlogEntryService, BlogEntryService>();
        serviceCollection.AddSingleton<ICommentService, CommentService>();
        return serviceCollection;
    }

    public static IServiceCollection UseSwaggerGen(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "Blog API", Version = "v1" });
        });

        return serviceCollection;
    }
}
