using MediatR;
using TrafficLaws.Application.Features.Result.Query;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses.Result;

namespace TrafficLaws.Application.Features.Result.Handler;

public class GetUserResultHandler : IRequestHandler<GetUserResultQuery, UserResultResponse>
{
    private readonly IResultRepository _resultRepository;

    public GetUserResultHandler(IResultRepository resultRepository)
    {
        _resultRepository = resultRepository;
    }
    public async Task<UserResultResponse> Handle(GetUserResultQuery request, CancellationToken cancellationToken)
    {
        var result = await _resultRepository.GetUserRessult(Guid.Parse(request.UserId), cancellationToken);

        if (result.Count == 0)
            return new UserResultResponse { IsSuccessfully = true, Message = "Results not found" };

        return new UserResultResponse
        {
            IsSuccessfully = true,
            Results = result,
            TotalCount = result.Count, 
            Tests = result.Select(x => x.Test).ToList()
        };
    }
}