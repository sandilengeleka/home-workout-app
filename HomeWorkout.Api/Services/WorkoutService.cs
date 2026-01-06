using HomeWorkout.Api.Data;
using HomeWorkout.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkout.Api.Services;

public class WorkoutService(HomeWorkoutContext context) : IWorkoutService
{
    private readonly HomeWorkoutContext _dbcontext = context;

    public Workout? GetWithExercises(int id)
    {
        return _dbcontext.Workouts
            .Include(w => w.Exercises) // eager load exercises
            .FirstOrDefault(w => w.Id == id);
    }

    public IEnumerable<Workout> GetAll() => _dbcontext.Workouts.ToList();

    public Workout? GetById(int id) => _dbcontext.Workouts.Find(id);

    public Workout Create(Workout workout)
    {
        _dbcontext.Workouts.Add(workout);
        _dbcontext.SaveChanges();
        return workout;
    }

    public bool Update(int id, Workout workout)
    {
        var existingWorkout = _dbcontext.Workouts.Find(id);
        if (existingWorkout == null) return false;

        existingWorkout.Name = workout.Name;
        existingWorkout.Description = workout.Description;
        existingWorkout.DifficultyLevel = workout.DifficultyLevel;
        existingWorkout.DurationInMinutes = workout.DurationInMinutes;

        _dbcontext.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var workout = _dbcontext.Workouts.Find(id);
        if (workout == null) return false;

        _dbcontext.Workouts.Remove(workout);
        _dbcontext.SaveChanges();
        return true;
    }

    public Workout? GetWorkoutWithExercises(int id)
    {
        return _dbcontext.Workouts
            .Include(w => w.Exercises)
            .FirstOrDefault(w => w.Id == id);
    }
}

    