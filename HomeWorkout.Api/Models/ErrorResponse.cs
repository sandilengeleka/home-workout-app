namespace HomeWorkout.Api.Models;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string Messsage { get; set; } = string.Empty;
    public string Detail { get; set; } = string.Empty;
}