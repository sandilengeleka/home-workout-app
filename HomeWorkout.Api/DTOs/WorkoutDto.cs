namespace HomeWorkout.Api.DTOs;

public class WorkoutDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DifficultyLevel { get; set; } = string.Empty;
    public int DurationInMinutes { get; set; }
}