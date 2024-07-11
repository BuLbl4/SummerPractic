using MediatR;
using TrafficLaws.Application.Features.Result.DTO;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Result.Query;

public class AddUserAnswersQuery : UserAnswerRequest, IRequest<BaseResponse>
{
    public AddUserAnswersQuery(UserAnswerRequest request) : base(request)
    {
    }
}