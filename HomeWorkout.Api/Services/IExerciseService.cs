using HomeWorkout.Api.Models;

namespace HomeWorkout.Api.Services;

public interface IExerciseService
{
    IEnumerable<Exercise> GetByWorkout(int workoutId);
    Exercise CreateExercise(int workoutId, Exercise exercise);
}