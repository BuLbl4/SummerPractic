using MediatR;
using TrafficLaws.Application.Features.Profile.DTO;
using TrafficLaws.Application.Responses.User;

namespace TrafficLaws.Application.Features.Profile.Queries;


public class GetUserQuery : GetUserByIdRequest, IRequest<UserResponse>
{
    public GetUserQuery(GetUserByIdRequest request) : base(request)
    {
        
    }
}