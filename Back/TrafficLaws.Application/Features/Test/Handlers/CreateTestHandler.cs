using MediatR;
using TrafficLaws.Application.Features.Test.Queries;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Test.Handlers;

public class CreateTestHandler : IRequestHandler<CreateTestQuery, BaseResponse>
{
    private readonly ITestRepository _testRepository;

    public CreateTestHandler(ITestRepository testRepository)
    {
        _testRepository = testRepository;
    }
    public async Task<BaseResponse> Handle(CreateTestQuery request, CancellationToken cancellationToken)
    {
        var result = await _testRepository.CreateTest(request.Title, request.Description, cancellationToken);

        return new BaseResponse
        {
            IsSuccessfully = true,
            Message = $"{result.Id}"
        };
    }
}