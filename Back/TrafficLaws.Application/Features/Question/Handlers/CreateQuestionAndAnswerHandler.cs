using MediatR;
using TrafficLaws.Application.Features.Question.Queries;
using TrafficLaws.Application.Interfaces.Repository;
using TrafficLaws.Application.Responses;


namespace TrafficLaws.Application.Features.Question.Handlers
{
    public class CreateQuestionAndAnswerHandler : IRequestHandler<CreateQuestionAndAnswerQuery, BaseResponse>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IQuestionRepository _questionRepository;

        public CreateQuestionAndAnswerHandler(IAnswerRepository answerRepository,
            IQuestionRepository questionRepository)
        {
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
        }

        public async Task<BaseResponse> Handle(CreateQuestionAndAnswerQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                var question = new Domain.Entities.Question();

                if (request.CorrectAnswers.Count == 1)
                {
                    question =
                        await _questionRepository.CreateQuestion(request.Question, Guid.Parse(request.TestId), true,
                            cancellationToken);
                }
                else
                {
                    question =
                        await _questionRepository.CreateQuestion(request.Question, Guid.Parse(request.TestId), false,
                            cancellationToken);
                }

                var correctAnswerCount = request.CorrectAnswers.Count;

                if (request.QuestionType == "single" && correctAnswerCount != 1)
                {
                    return new BaseResponse
                    {
                        IsSuccessfully = false,
                        Message = "For 'single' QuestionType, there should be exactly one correct answer."
                    };
                }

                if (request.QuestionType == "multiple" && (correctAnswerCount < 1 || correctAnswerCount > 4))
                {
                    return new BaseResponse
                    {
                        IsSuccessfully = false,
                        Message = "For 'multiple' QuestionType, there should be one or two correct answers."
                    };
                }

                var answerCorrectnessList = new List<bool>(new bool[request.Options.Count]);
                for (int i = 0; i < request.Options.Count; i++)
                {
                    answerCorrectnessList[i] = request.CorrectAnswers.Contains(request.Options[i]);
                }

                await _answerRepository.AddAnswers(request.Options, answerCorrectnessList, question.Id,
                    cancellationToken);

                return new BaseResponse
                {
                    IsSuccessfully = true,
                    Message = $"Created question: {question.Id}; answersCount: {request.Options.Count}"
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BaseResponse { Message = $"{e.Message}" };
            }
        }
    }
}