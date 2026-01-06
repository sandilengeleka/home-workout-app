namespace HomeWorkout.Api.DTOs;

public class CreateExerciseDto
{
    public required string Name { get; set; } = string.Empty;
    public required string Description { get; set; } = string.Empty;
    public int Sets { get; set; }
    public int Reps { get; set; }
}