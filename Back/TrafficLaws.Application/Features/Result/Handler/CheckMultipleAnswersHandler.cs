using MediatR;
using TrafficLaws.Application.Features.Result.Query;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses.Result;

namespace TrafficLaws.Application.Features.Result.Handler
{
    public class CheckMultipleAnswersHandler : IRequestHandler<CheckMultipleAnswersQuery, MultipleAnswerResponse>
    {
        private readonly IAnswerRepository _answer;

        public CheckMultipleAnswersHandler(IAnswerRepository answer)
        {
            _answer = answer;
        }

        public async Task<MultipleAnswerResponse> Handle(CheckMultipleAnswersQuery request, CancellationToken cancellationToken)
        {
            var answers = await _answer.GetAnswersById(request.AnswerId.Select(id => id).ToList(), cancellationToken);
            
            var allAnswerbyQuestion = await _answer.GetAllAnswerByQuestion(Guid.Parse(request.QuestionId), cancellationToken);

            if (allAnswerbyQuestion.Count == 0 || answers.Count == 0)
                return new MultipleAnswerResponse { Message = "Answers not found" };
            
            var incorrectAnswers = answers
                .Where(answer => !answer.IsCorrect || answer.QuestionId != Guid.Parse(request.QuestionId))
                .Select(answer => answer.Id)
                .ToList();

            if (allAnswerbyQuestion.Count(x => x.IsCorrect) == answers.Count && incorrectAnswers.Count == 0)
                return new MultipleAnswerResponse { IsSuccessfully = true, Message = "Correct" };
            

            return new MultipleAnswerResponse
            {
                IsSuccessfully = true,
                Message = "One or more answers are incorrect",
                IncorrectAnswerIds = incorrectAnswers
            };
        }
    }
}