using HomeWorkout.Api.DTOs;
using HomeWorkout.Api.DTOs.Workouts;
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

    // GET: api/workouts
    [HttpGet]
    public IActionResult GetAll([FromQuery] WorkoutQueryDto query)
    {
        var workouts = _workoutService.GetPaged(query, out var totalCount);

        var result = workouts
            .Select(w => new WorkoutSummaryDto
            {
                Id = w.Id,
                Name = w.Name,
                DifficultyLevel = w.DifficultyLevel,
                DurationInMinutes = w.DurationInMinutes
            });

        return Ok(new
        {
            totalCount,
            page = query.Page,
            pageSize = query.PageSize,
            data = result
        });
    }

    // GET: api/workouts/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var workout = _workoutService.GetById(id);
        if (workout == null) return NotFound();

        var dto = new WorkoutDto
        {
            Id = workout.Id,
            Name = workout.Name,
            Description = workout.Description,
            DifficultyLevel = workout.DifficultyLevel,
            DurationInMinutes = workout.DurationInMinutes
        };

        return Ok(dto);
    }

    // GET: api/workouts/{id}/with-exercises
    [HttpGet("{id}/with-exercises")]
    public IActionResult GetWithExercises(int id)
    {
        var workout = _workoutService.GetWorkoutWithExercises(id);
        if (workout == null) return NotFound();

        var dto = new WorkoutDetailsDto
        {
            Id = workout.Id,
            Name = workout.Name,
            Description = workout.Description,
            DifficultyLevel = workout.DifficultyLevel,
            DurationInMinutes = workout.DurationInMinutes,
            Exercises = workout.Exercises.Select(e => new ExerciseDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Sets = e.Sets,
                Reps = e.Reps
            }).ToList()
        };

        return Ok(dto);
    }

    // POST: api/workouts
    [HttpPost]
    public IActionResult Create([FromBody] CreateWorkoutDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var workout = new Workout
        {
            Name = dto.Name,
            Description = dto.Description,
            DifficultyLevel = dto.DifficultyLevel,
            DurationInMinutes = dto.DurationInMinutes
        };

        var createdWorkout = _workoutService.Create(workout);

        var response = new WorkoutDto
        {
            Id = createdWorkout.Id,
            Name = createdWorkout.Name,
            Description = createdWorkout.Description,
            DifficultyLevel = createdWorkout.DifficultyLevel,
            DurationInMinutes = createdWorkout.DurationInMinutes
        };

        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    // PUT: api/workouts/{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] CreateWorkoutDto dto)
    {

        if (!ModelState.IsValid) return BadRequest(ModelState);

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

    // Delete a workout
    [HttpDelete("{id}")] 
    public IActionResult Delete(int id)
    {
        var deleted = _workoutService.Delete(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}