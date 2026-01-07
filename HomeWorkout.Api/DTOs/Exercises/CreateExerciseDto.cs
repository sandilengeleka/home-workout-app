using System.ComponentModel.DataAnnotations;

namespace HomeWorkout.Api.DTOs;

public class CreateExerciseDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(300)]
    public string Description { get; set; } = string.Empty;

    [Range(1, 50)]
    public int Sets { get; set; }

    [Range(1, 100)]
    public int Reps { get; set; }
}