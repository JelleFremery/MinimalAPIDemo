using MinimalAPIDemo.AppCore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IBlogEntryService, BlogEntryService>();
builder.Services.AddSingleton<ICommentService, CommentService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
