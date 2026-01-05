namespace HomeWorkout.Api.DTOs;

public class CreateWorkoutDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string DifficultyLevel { get; set; }
    public int DurationInMinutes { get; set; }
}