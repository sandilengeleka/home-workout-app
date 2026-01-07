namespace HomeWorkout.Api.DTOs;

public class WorkoutQueryDto
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Difficulty { get; set; }
    public string? SortBy { get; set; } // duration, name, etc.
}