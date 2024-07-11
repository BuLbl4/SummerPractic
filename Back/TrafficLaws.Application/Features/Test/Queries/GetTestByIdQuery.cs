using MediatR;
using TrafficLaws.Application.Features.Test.DTO;
using TrafficLaws.Application.Responses.Test;

namespace TrafficLaws.Application.Features.Test.Queries;

public class GetTestByIdQuery : GetTestByIdRequest, IRequest<TestResponse>
{
    public GetTestByIdQuery(GetTestByIdRequest request) : base(request)
    {
        
    }
}