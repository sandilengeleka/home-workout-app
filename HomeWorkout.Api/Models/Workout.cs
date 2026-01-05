namespace HomeWorkout.Api.Models;

public class Workout
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string DifficultyLevel { get; set; }
    public int DurationInMinutes { get; set; }
}
