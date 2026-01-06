using HomeWorkout.Api.Data;
using HomeWorkout.Api.Models;

namespace HomeWorkout.Api.Services;

public class ExerciseService : IExerciseService
{
    private readonly HomeWorkoutContext _context;

    public ExerciseService(HomeWorkoutContext context)
    {
        _context = context;
    }

    public IEnumerable<Exercise> GetByWorkout(int workoutId)
    {
        return _context.Exercises
            .Where(e => e.WorkoutId == workoutId)
            .ToList();
    }

    public Exercise CreateExercise(int workoutId, Exercise exercise)
    {
        exercise.WorkoutId = workoutId;
        _context.Exercises.Add(exercise);
        _context.SaveChanges();
        return exercise;
    }
}