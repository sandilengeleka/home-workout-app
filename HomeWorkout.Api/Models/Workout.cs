using System.ComponentModel.DataAnnotations;

namespace HomeWorkout.Api.Models;

public class Workout
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DifficultyLevel { get; set; } = string.Empty;
    public int DurationInMinutes { get; set; }

    public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
