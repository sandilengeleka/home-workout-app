using HomeWorkout.Api.Data;
using HomeWorkout.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkout.Api.Services;

public class WorkoutService : IWorkoutService
{
    private readonly HomeWorkoutContext _context;

    public WorkoutService(HomeWorkoutContext context)
    {
        _context = context;
    }

    public IEnumerable<Workout> GetAll() => _context.Workouts.ToList();

    public Workout? GetById(int id) => _context.Workouts.Find(id);

    public Workout Create(Workout workout)
    {
        _context.Workouts.Add(workout);
        _context.SaveChanges();
        return workout;
    }

    public bool Update(int id, Workout workout)
    {
        var existingWorkout = _context.Workouts.Find(id);
        if (existingWorkout == null) return false;

        existingWorkout.Name = workout.Name;
        existingWorkout.Description = workout.Description;
        existingWorkout.DifficultyLevel = workout.DifficultyLevel;
        existingWorkout.DurationInMinutes = workout.DurationInMinutes;

        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var workout = _context.Workouts.Find(id);
        if (workout == null) return false;

        _context.Workouts.Remove(workout);
        _context.SaveChanges();
        return true;
    }
}

    