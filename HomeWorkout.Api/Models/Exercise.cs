using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWorkout.Api.Models;

public class Exercise
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int Sets { get; set; }
    public int Reps { get; set; }

    // Foreign key to Workout
    public int WorkoutId { get; set; }

    public Workout? Workout { get; set; }
}