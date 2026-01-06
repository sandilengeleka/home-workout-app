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

    // Get all exercises for a specific workout
    [HttpGet]
    public IActionResult GetAll(int workoutId)
    {
        var exercises = _exerciseService.GetByWorkout(workoutId)
        .Select(e => new ExerciseDto
        {
            Id = e.Id,
            Name = e.Name,
            Description = e.Description,
            Sets = e.Sets,
            Reps = e.Reps
        });

        return Ok(exercises);
    }


    // Get exercise by ID
    [HttpGet("{id}")]
    public IActionResult GetById(int workoutId, int id)
    {
        var exercise = _exerciseService.GetById(workoutId, id) as Exercise;
        if (exercise == null) return NotFound();
        
        var dto = new ExerciseDto
        {
            Id = exercise.Id,
            Name = exercise.Name,
            Description = exercise.Description,
            Sets = exercise.Sets,
            Reps = exercise.Reps
        };

        return Ok(dto);
    }

    // Create a new exercise for a specific workout
    [HttpPost]
    public IActionResult CreateExercise(int workoutId, CreateExerciseDto dto)
    {

        if (!ModelState.IsValid) return BadRequest(ModelState);        

        var exercise = new Exercise
        {
            Name = dto.Name,
            Description = dto.Description,
            Sets = dto.Sets,
            Reps = dto.Reps,
        };

        var createdExercise = _exerciseService.CreateExercise(workoutId, exercise);

        var response = new ExerciseDto
        {
            Id = createdExercise.Id,
            Name = createdExercise.Name,
            Description = createdExercise.Description,
            Sets = createdExercise.Sets,
            Reps = createdExercise.Reps
        };

        return CreatedAtAction(nameof(GetById), new { workoutId = workoutId, id = response.Id }, response);
    }

    // Update an existing exercise
    [HttpPut("{id}")]
    public IActionResult UpdateExercise(int workoutId, int id, [FromBody] UpdateExerciseDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var existingExercise = new Exercise
        {
            Name = dto.Name,
            Description = dto.Description,
            Sets = dto.Sets,
            Reps = dto.Reps
        };

        var updated = _exerciseService.UpdateExercise(workoutId, id, existingExercise);
        if (!updated) return NotFound();

        return NoContent();
    }

    // Delete an exercise
    [HttpDelete("{id}")]
    public IActionResult DeleteExercise(int workoutId, int id)
    {
        var deleted = _exerciseService.DeleteExercise(workoutId, id);
        if (!deleted) return NotFound();
        
        return NoContent();
    }
}
