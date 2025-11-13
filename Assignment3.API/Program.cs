using Microsoft.EntityFrameworkCore;
using Assignment3.Core.Interfaces;
using Assignment3.Infrastructure.Repositories;
using Assignment3.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(); // Required for JSON Patch support

// Configure SQLite Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Register Repositories
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

// Ensure that you are running the in the API folder
app.Run();
