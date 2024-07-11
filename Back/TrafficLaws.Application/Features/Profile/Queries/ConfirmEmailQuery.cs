using MediatR;
using TrafficLaws.Application.Features.Profile.DTO;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Profile.Queries;

public class ConfirmEmailQuery : ConfirmEmailRequest, IRequest<BaseResponse>
{
    public ConfirmEmailQuery(ConfirmEmailRequest request) : base(request)
    {
        
    }
}