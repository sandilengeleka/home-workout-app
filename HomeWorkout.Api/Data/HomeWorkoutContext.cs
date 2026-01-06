using HomeWorkout.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkout.Api.Data;
public class HomeWorkoutContext : DbContext
{
    public HomeWorkoutContext(DbContextOptions<HomeWorkoutContext> options) : base(options)
    {
        
    }
    public DbSet<Workout> Workouts => Set<Workout>();
    public DbSet<Exercise> Exercises => Set<Exercise>();
}
