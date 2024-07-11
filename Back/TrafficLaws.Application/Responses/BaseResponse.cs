namespace TrafficLaws.Application.Responses;

public class BaseResponse
{
    public bool IsSuccessfully { get; set; }
    
    public int? TotalCount { get; set; }
    
    public List<string>? Errors { get; set; }
    
    public string? Message { get; set; }    
}