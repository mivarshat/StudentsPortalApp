using Microsoft.EntityFrameworkCore;
using StudentsPortalApp.EFContext;
using StudentsPortalApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<StudentPortalDBContext>(options => options.UseSqlServer("Server=tcp:studentportaldb-server.database.windows.net,1433;Initial Catalog=studentinformationdb;Persist Security Info=False;User ID=HVSolutionTech;Password=StudentPortal@123;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
builder.Services.AddDbContext<StudentInformationlDBContext>(options => options.UseSqlServer("Server=tcp:studentportaldb-server.database.windows.net,1433;Initial Catalog=studentinformationdb;Persist Security Info=False;User ID=HVSolutionTech;Password=StudentPortal@123;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
