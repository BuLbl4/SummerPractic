using MediatR;
using TrafficLaws.Application.Features.Test.DTO;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Test.Queries;

public class CreateUserTestQuery : CreateUserTestRequest, IRequest<BaseResponse>
{
    public CreateUserTestQuery(CreateUserTestRequest request) : base(request)
    {
        
    }
}