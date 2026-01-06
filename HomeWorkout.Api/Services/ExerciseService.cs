using HomeWorkout.Api.Data;
using HomeWorkout.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkout.Api.Services;

public class ExerciseService : IExerciseService
{
    private readonly HomeWorkoutContext _dbContext;

    public ExerciseService(HomeWorkoutContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Exercise> GetByWorkout(int workoutId)
    {
        return _dbContext.Exercises
            .Where(e => e.WorkoutId == workoutId)
            .ToList();
    }
    public Exercise? GetById(int workoutId, int id)
    {
        return _dbContext.Exercises
            .FirstOrDefault(e => e.WorkoutId == workoutId && e.Id == id);
    }

    public Exercise CreateExercise(int workoutId, Exercise exercise)
    {
        exercise.WorkoutId = workoutId;
        _dbContext.Exercises.Add(exercise);
        _dbContext.SaveChanges();
        return exercise;
    }
    public bool UpdateExercise(int workoutId, int id, Exercise updatedExercise)
    {
        var existingExercise = GetById(workoutId, id);
        if (existingExercise == null) return false;

        existingExercise.Name = updatedExercise.Name;
        existingExercise.Description = updatedExercise.Description;
        existingExercise.Sets = updatedExercise.Sets;
        existingExercise.Reps = updatedExercise.Reps; 

        _dbContext.SaveChanges();
        return true;
    }

    public bool DeleteExercise(int workoutId, int Id)
        {
            var existing = GetById(workoutId, Id);
            if (existing == null) return false;
    
            _dbContext.Exercises.Remove(existing);
            _dbContext.SaveChanges();
            return true;
        }
}
