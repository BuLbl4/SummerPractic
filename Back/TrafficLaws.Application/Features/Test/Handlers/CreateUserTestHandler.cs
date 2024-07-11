using MediatR;
using TrafficLaws.Application.Features.Test.Queries;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses;

namespace TrafficLaws.Application.Features.Test.Handlers;

public class CreateUserTestHandler : IRequestHandler<CreateUserTestQuery, BaseResponse>
{
    private readonly ITestRepository _testRepository;

    public CreateUserTestHandler(ITestRepository testRepository)
    {
        _testRepository = testRepository;
    }
    public async Task<BaseResponse> Handle(CreateUserTestQuery request, CancellationToken cancellationToken)
    {
        var res = await _testRepository.CreateTest(request.Name, request.Description, cancellationToken);

        return new BaseResponse { IsSuccessfully = true, Message = $"Create test: {res.Id}" };
    }
}