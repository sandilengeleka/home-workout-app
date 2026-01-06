namespace HomeWorkout.Api.DTOs.Workouts;

public class WorkoutSummaryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DifficultyLevel { get; set; } = string.Empty;
    public int DurationInMinutes { get; set; }
}