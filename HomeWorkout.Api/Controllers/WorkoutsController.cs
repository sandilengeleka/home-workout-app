using HomeWorkout.Api.DTOs;
using HomeWorkout.Api.Models;
using HomeWorkout.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeWorkout.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutsController : ControllerBase
{
    private readonly IWorkoutService _workoutService;

    public WorkoutsController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_workoutService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var workout = _workoutService.GetById(id);
        if (workout == null) return NotFound();
        return Ok(workout);
    }

    [HttpPost]
    public IActionResult Create(CreateWorkoutDto dto)
    {
        var workout = new Workout
        {
            Name = dto.Name,
            Description = dto.Description,
            DifficultyLevel = dto.DifficultyLevel,
            DurationInMinutes = dto.DurationInMinutes
        };

        var createdWorkout = _workoutService.Create(workout);
        return CreatedAtAction(nameof(GetById), new { id = createdWorkout.Id }, createdWorkout);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, CreateWorkoutDto dto)
    {
        var workout = new Workout
        {
            Name = dto.Name,
            Description = dto.Description,
            DifficultyLevel = dto.DifficultyLevel,
            DurationInMinutes = dto.DurationInMinutes
        };
        
        var updated = _workoutService.Update(id, workout);
        if (!updated) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")] 
    public IActionResult Delete(int id)
    {
        var deleted = _workoutService.Delete(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}
