using Microsoft.EntityFrameworkCore;
using Tutorial10.RestAPI;

// using Tutorial10.RestAPI;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("UniversityConnection") ?? throw new InvalidOperationException("Connection string not found");
builder.Services.AddDbContext<_2019sbdContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/jobs", async (_2019sbdContext db) =>
{
    return await db.Jobs.ToListAsync();
});

app.MapGet("/api/departments", async (_2019sbdContext db) => {
    return await db.Departemnts.ToListAsync();
});

app.MapGet("/api/employees", async (_2019sbdContext db) =>
{   
    return await db.Employees
        .Include(e => e.Job)
        .Include(e => e.Department)
        .ToListAsync();
});

app.MapGet("/api/employees/{id}", (int id) =>
{
    
});

app.MapPost("/api/employees", () =>
{
    
});

app.MapPut("/api/employees/{id}", (int id) =>
{
    
});

app.MapDelete("/api/employees/{id}", (int id) =>
{
    
});

app.Run();
