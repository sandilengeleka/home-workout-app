namespace HomeWorkout.Api.DTOs;

public class WorkoutWithExerciseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DifficultyLevel { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
    public List<ExerciseDto> Exercises { get; set; } = new();
}