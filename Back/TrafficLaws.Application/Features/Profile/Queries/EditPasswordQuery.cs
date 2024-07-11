using MediatR;
using TrafficLaws.Application.Features.Profile.DTO;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Profile.Queries;

public class EditPasswordQuery : EditPasswordRequest, IRequest<BaseResponse>
{
    public EditPasswordQuery(EditPasswordRequest request) : base(request)
    {
        
    }
}