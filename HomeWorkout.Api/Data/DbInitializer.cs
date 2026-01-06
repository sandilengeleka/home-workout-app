using HomeWorkout.Api.Models;

namespace HomeWorkout.Api.Data;

public static class DbInitializer
{
    public static void Seed(HomeWorkoutContext context)
    {
        // Ensure database exists
        context.Database.EnsureCreated();

        // If data already exists, do nothing
        if (context.Workouts.Any())
            return; // DB has been seeded

        var workouts = new List<Workout>
        {
            new Workout 
            { 
                Name = "Push Day",
                Description = "A workout focused on pushing exercises.",
                DifficultyLevel = "Intermediate",
                DurationInMinutes = 45, 
            },

            new Workout 
            { 
                Name = "Pull Day",
                Description = "A workout focused on pulling exercises.",
                DifficultyLevel = "Intermediate",
                DurationInMinutes = 45, 
            },

            new Workout 
            { 
                Name = "Leg Day",
                Description = "A workout focused on leg exercises.",
                DifficultyLevel = "Advanced",
                DurationInMinutes = 60, 
            }
        };

        context.Workouts.AddRange(workouts);
        context.SaveChanges();
    }
}