using MediatR;
using TrafficLaws.Application.Features.Test.Queries;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses.Test;

namespace TrafficLaws.Application.Features.Test.Handlers;

public class GetRandomTestHandler : IRequestHandler<GetRandomTestQuery, TestResponse>
{
    private readonly ITestRepository _testRepository;

    public GetRandomTestHandler(ITestRepository testRepository)
    {
        _testRepository = testRepository;
    }
    public async Task<TestResponse> Handle(GetRandomTestQuery request, CancellationToken cancellationToken)
    {
        var res = await _testRepository.GetRandomTest(cancellationToken);
        

        return new TestResponse
        {
            IsSuccessfully = true,
            Answers = res.Questions.Select(x => x.Answers.Select(x => x.AnswerText).ToList()).ToList(),
            Questions = res.Questions,
            TestName = res.Title,
            Id = res.Id.ToString(),
            Description = res.Description
        };
    }
}