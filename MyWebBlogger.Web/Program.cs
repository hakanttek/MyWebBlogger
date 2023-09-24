using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyWebBlogger.Application.Common;
using MyWebBlogger.Application.Posts;
using MyWebBlogger.Application.Projects;
using MyWebBlogger.Contracts.Application.Posts;
using MyWebBlogger.Contracts.Application.Projects;
using MyWebBlogger.Contracts.Infrastructure.Common;
using MyWebBlogger.Domain.Posts;
using MyWebBlogger.Domain.Projects;
using MyWebBlogger.Infrastructure.Data;
using MyWebBlogger.Infrastructure.Posts;
using MyWebBlogger.Infrastructure.Projects;
    
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add your services here
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure();
        }));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Register repositories and app services
builder.Services.AddTransient<IPostDto, PostDto>();
builder.Services.AddScoped<IRepository<Post>, PostRepository>();
builder.Services.AddScoped<IPostAppService, PostAppService>();
builder.Services.AddTransient<IProjectDto, ProjectDto>();
builder.Services.AddScoped<IRepository<Project>, ProjectRepository>();
builder.Services.AddScoped<IProjectAppService, ProjectAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();