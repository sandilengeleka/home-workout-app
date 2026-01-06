namespace HomeWorkout.Api.DTOs;

public class UpdateExerciseDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Sets { get; set; }
    public int Reps { get; set; }
}