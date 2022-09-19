using Serilog;
using Serilog.Events;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Host.UseSerilog((ctx, lc) => lc
.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
.MinimumLevel.Error()
.WriteTo.Console()
.WriteTo.Seq("http://localhost:5341/").MinimumLevel.Error()
.WriteTo.File(
    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Logs", "log.txt"),
    rollingInterval: RollingInterval.Day,
    fileSizeLimitBytes: 10 * 1024 * 1024,
    retainedFileCountLimit: 30,
    rollOnFileSizeLimit: true,
    flushToDiskInterval: TimeSpan.FromSeconds(2))
.WriteTo.MSSqlServer("server=DESKTOP-QBQM5QA\\SQLEXPRESS;database=SerilogDb;Trusted_Connection=true", "Logs")
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
