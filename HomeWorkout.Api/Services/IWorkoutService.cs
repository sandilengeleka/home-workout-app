using HomeWorkout.Api.Models;

namespace HomeWorkout.Api.Services;

public interface IWorkoutService
{
    IEnumerable<Workout> GetAll();
    Workout? GetById(int id);
    Workout Create(Workout workout);
    bool Update(int id, Workout workout);
    bool Delete(int id);
}