using HomeWorkout.Api.DTOs;
using HomeWorkout.Api.Services;
using HomeWorkout.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeWorkout.Api.Controllers;

[ApiController]
[Route("api/workouts/{workoutId}/[controller]")]

public class ExercisesController : ControllerBase
{
    private readonly IExerciseService _exerciseService;

    public ExercisesController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    [HttpGet]
    public IActionResult GetAll(int workoutId)
    {
        return Ok(_exerciseService.GetByWorkout(workoutId));
    }

    [HttpPost]
    public IActionResult CreateExercise(int workoutId, CreateExerciseDto dto)
    {
        var exercise = new Exercise
        {
            Name = dto.Name,
            Description = dto.Description,
            Sets = dto.Sets,
            Reps = dto.Reps,
        };
        var createdExercise = _exerciseService.CreateExercise(workoutId, exercise);
        return Ok(createdExercise);
    }
}
