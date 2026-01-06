using System.ComponentModel.DataAnnotations;

namespace HomeWorkout.Api.Models;

public class Workout
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; } = string.Empty;
    public required string Description { get; set; } = string.Empty;
    public required string DifficultyLevel { get; set; } = string.Empty;
    public int DurationInMinutes { get; set; }
}
