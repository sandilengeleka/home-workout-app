namespace HomeWorkout.Api.DTOs.Workouts;

public class WorkoutDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DifficultyLevel { get; set; } = string.Empty;
    public int DurationInMinutes { get; set; }

    public List<ExerciseDto> Exercises { get; set; } = new();
}