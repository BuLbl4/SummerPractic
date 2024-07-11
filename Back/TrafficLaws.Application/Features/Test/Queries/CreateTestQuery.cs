using MediatR;
using TrafficLaws.Application.Features.Test.DTO;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Test.Queries;

public class CreateTestQuery : CreateTestRequest, IRequest<BaseResponse>
{
    public CreateTestQuery(CreateTestRequest request) : base(request)
    {
        
    }
}