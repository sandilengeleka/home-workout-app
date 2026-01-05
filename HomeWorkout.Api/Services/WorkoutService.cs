using HomeWorkout.Api.Models;

namespace HomeWorkout.Api.Services;

public class WorkoutService : IWorkoutService
{
    private static readonly List<Workout> _workouts = [];

    public IEnumerable<Workout> GetAll() => _workouts;

    public Workout? GetById(int id) => _workouts.FirstOrDefault(w => w.Id == id);

    public Workout Create(Workout workout)
    {
        workout.Id = _workouts.Count + 1;
        _workouts.Add(workout);
        return workout;
    }

    public bool Update(int id,Workout workout)
    {
        var existingWorkout = _workouts.FirstOrDefault(w => w.Id == workout.Id);
        if (existingWorkout == null) return false;

        existingWorkout.Name = workout.Name;
        existingWorkout.Description = workout.Description;
        existingWorkout.DifficultyLevel = workout.DifficultyLevel;
        existingWorkout.DurationInMinutes = workout.DurationInMinutes;
        return true;
    }

    public bool Delete(int id)
    {
        var workout = _workouts.FirstOrDefault(w => w.Id == id);
        if (workout == null) return false;

        _workouts.Remove(workout);
        return true;
    }
}

    