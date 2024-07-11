using MediatR;
using TrafficLaws.Application.Features.Test.Queries;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses.Test;

namespace TrafficLaws.Application.Features.Test.Handlers;

public class GetTestByIdHandler : IRequestHandler<GetTestByIdQuery, TestResponse>
{
    private readonly ITestRepository _repository;

    public GetTestByIdHandler(ITestRepository repository)
    {
        _repository = repository;
    }

    public async Task<TestResponse> Handle(GetTestByIdQuery request, CancellationToken cancellationToken)
    {
        var test = await _repository.GetTestById(Guid.Parse(request.Id), cancellationToken);

        if (test == null)
            return new TestResponse { IsSuccessfully = false, Message = "Test not found" };

        return new TestResponse
        {
            IsSuccessfully = true,
            Id = test.Id.ToString(),
            TestName = test.Title,
            Description = test.Description!,
            Questions = test.Questions,
            Answers = test.Questions.Select(x => x.Answers.Select(x => x.AnswerText).ToList()).ToList()
        };
    }
}