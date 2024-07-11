using MediatR;
using TrafficLaws.Application.Features.Result.Query;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses.Result;

namespace TrafficLaws.Application.Features.Result.Handler;

public class SubmitResultHandler : IRequestHandler<SubmitResultQuery, ResultResponse>
{
    private readonly IResultRepository _repository;

    public SubmitResultHandler(IResultRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultResponse> Handle(SubmitResultQuery request, CancellationToken cancellationToken)
    {
        await _repository.AddResult(Guid.Parse(request.UserId), Guid.Parse(request.TestId), request.Score,
            cancellationToken);

        return new ResultResponse
        {
            IsSuccessfully = true,
        };
    }
}