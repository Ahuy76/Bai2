using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SuKien.Data;
using SuKien.Services.Interfaces;
using SuKien.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // This adds MVC support, including TempData.
builder.Services.AddEndpointsApiExplorer();

// Add Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TrangSuKien API",
        Version = "v1",
        Description = "API for managing Event"
    });
});


// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader();
        });
});

// Add DB Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

// Thêm dịch vụ của bạn vào DI container
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<SuKien.Services.IEventService, EventService>();
builder.Services.AddScoped<ISponsorService, SponsorService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IQRCheckinService, QRCheckinService>();
builder.Services.AddScoped<IPostLikeService, PostLikeService>();
builder.Services.AddScoped<IEventLikeService, EventLikeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrangSuKien API V1");
        c.RoutePrefix = string.Empty; // Makes Swagger UI available at the root of the app
    });
}

// Enable HTTPS redirection
app.UseHttpsRedirection();
app.UseStaticFiles();
// Enable CORS for all origins
app.UseCors("AllowAll");

// Enable Authorization Middleware
app.UseAuthorization();

// Map Controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the app
app.Run();




