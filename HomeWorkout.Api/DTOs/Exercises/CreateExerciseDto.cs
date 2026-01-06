using System.ComponentModel.DataAnnotations;

namespace HomeWorkout.Api.DTOs;

public class CreateExerciseDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Range(1, 50)]
    public int Sets { get; set; }

    [Range(1, 100)]
    public int Reps { get; set; }
}