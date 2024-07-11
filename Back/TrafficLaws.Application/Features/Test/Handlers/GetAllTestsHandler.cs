using MediatR;
using TrafficLaws.Application.Features.Test.Queries;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses.Test;

namespace TrafficLaws.Application.Features.Test.Handlers;

public class GetAllTestsHandler : IRequestHandler<GetAllTestsQuery, TestListResponse>
{
    private readonly ITestRepository _testRepository;

    public GetAllTestsHandler(ITestRepository testRepository)
    {
        _testRepository = testRepository;
    }
    public async Task<TestListResponse> Handle(GetAllTestsQuery request, CancellationToken cancellationToken)
    {
        var res = await _testRepository.GetTests(cancellationToken);
        
        return new TestListResponse
        {
            IsSuccessfully = true,
            Tests = res
        };
    }
}