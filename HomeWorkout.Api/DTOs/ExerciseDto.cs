namespace HomeWorkout.Api.DTOs;

public class ExerciseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Sets { get; set; }
    public int Reps { get; set; }
}
