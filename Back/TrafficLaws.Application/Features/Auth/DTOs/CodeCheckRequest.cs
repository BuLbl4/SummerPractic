namespace TrafficLaws.Application.Features.Auth.DTOs;

public class CodeCheckRequest
{
    public CodeCheckRequest()
    { }

    public CodeCheckRequest(CodeCheckRequest request)
    {
        Code = request.Code;
        CodeType = request.CodeType;
        Email = request.Email;
    }
    public string Email { get; set; }
    public string Code { get; set; }
    
    public string CodeType { get; set; }
}