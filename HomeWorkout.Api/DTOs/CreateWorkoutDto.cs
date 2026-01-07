using System.ComponentModel.DataAnnotations;

namespace HomeWorkout.Api.DTOs;

public class CreateWorkoutDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(300)]
    public string Description { get; set; } = string.Empty;
    public string DifficultyLevel { get; set; } = string.Empty;

    [Range(5, 240)]
    public int DurationInMinutes { get; set; }
}