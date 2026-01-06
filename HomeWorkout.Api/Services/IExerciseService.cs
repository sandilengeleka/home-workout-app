using HomeWorkout.Api.Models;

namespace HomeWorkout.Api.Services;

public interface IExerciseService
{
    IEnumerable<Exercise> GetByWorkout(int workoutId);
    Exercise? GetById(int workoutId, int id);

    Exercise CreateExercise(int workoutId, Exercise exercise);  

    bool UpdateExercise(int workoutId, int id, Exercise existingExercise);

    bool DeleteExercise(int workoutId, int id);
}