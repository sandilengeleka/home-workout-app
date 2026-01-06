using HomeWorkout.Api.Data;
using HomeWorkout.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core DbContext
builder.Services.AddDbContext<HomeWorkoutContext>(options => 
    options.UseSqlite("Data Source=homeworkout.db"));

// App services
builder.Services.AddScoped<IWorkoutService, WorkoutService>();

var app = builder.Build();

// swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();