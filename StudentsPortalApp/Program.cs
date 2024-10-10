using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Debugging;
using StudentsPortalApp.EFContext;
using StudentsPortalApp.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/MyAppLog.txt")
    .CreateLogger();


builder.Host.UseSerilog();

// Add services to the container.
//builder.Services.AddDbContext<StudentPortalDBContext>(options => options.UseSqlServer("Server=tcp:studentportaldb-server.database.windows.net,1433;Initial Catalog=studentinformationdb;Persist Security Info=False;User ID=HVSolutionTech;Password=StudentPortal@123;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
builder.Services.AddDbContext<StudentInformationlDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Student Portal API Version-1", Version = "1.0" });
    options.SwaggerDoc("2.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Student Portal API Version-2", Version = "2.0" });
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    options.DocInclusionPredicate((version, apiDesc) =>
    {
        if (!apiDesc.TryGetMethodInfo(out MethodInfo method))
            return false;
        var methodVersions = method.GetCustomAttributes(true)
                            .OfType<ApiVersionAttribute>()
                            .SelectMany(attr => attr.Versions);
        var controllerVersions = method.DeclaringType?
                           .GetCustomAttributes(true)
                           .OfType<ApiVersionAttribute>()
                           .SelectMany(attr => attr.Versions);
        var allVersions = methodVersions.Union(controllerVersions).Distinct();
        return allVersions.Any(v => v.ToString() == version);
    });
});
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/1.0/swagger.json", "Student Portal API Version-1");
        options.SwaggerEndpoint("/swagger/2.0/swagger.json", "Student Portal API Version-2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
