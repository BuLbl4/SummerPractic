using Domain.Entities;

namespace TrafficLaws.Persistence.DbSeeder;

public class Seeder
{
    public static IReadOnlyCollection<Test> Tests()
    {
        var test1 = new Test
        {
            Id = Guid.NewGuid(),
            Title = "Тест 1",
            Description = "Тест на знание основных правил дорожного движения"
        };

        var test2 = new Test
        {
            Id = Guid.NewGuid(),
            Title = "Тест 2",
            Description = "Тест на знание продвинутых правил дорожного движения"
        };

        return new List<Test> { test1, test2 };
    }

    public static IReadOnlyCollection<Question> Quaternions()
    {
        var tests = Tests().ToList(); // Получаем список тестов

        var question1 = new Question
        {
            Id = Guid.NewGuid(),
            TestId = tests[0].Id, // Привязываем вопрос к первому тесту
            QuestionText = "Какова допустимая скорость в жилой зоне?"
        };

        var question2 = new Question
        {
            Id = Guid.NewGuid(),
            TestId = tests[0].Id,
            QuestionText = "Что следует делать на красный сигнал светофора?"
        };

        var question3 = new Question
        {
            Id = Guid.NewGuid(),
            TestId = tests[1].Id, // Привязываем вопрос ко второму тесту
            QuestionText = "Каково наказание за проезд на красный свет?"
        };

        var question4 = new Question
        {
            Id = Guid.NewGuid(),
            TestId = tests[1].Id,
            QuestionText = "Как следует поступать на пешеходном переходе?"
        };

        return new List<Question> { question1, question2, question3, question4 };
    }

    public static IReadOnlyCollection<Answer> Answers()
    {
        var questions = Quaternions().ToList(); // Получаем список вопросов

        var answer1 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[0].Id, // Привязываем ответ к первому вопросу
            AnswerText = "30 км/ч",
            IsCorrect = true
        };

        var answer2 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[0].Id,
            AnswerText = "50 км/ч",
            IsCorrect = false
        };

        var answer3 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[0].Id,
            AnswerText = "60 км/ч",
            IsCorrect = false
        };

        var answer4 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[0].Id,
            AnswerText = "70 км/ч",
            IsCorrect = false
        };

        var answer5 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[1].Id,
            AnswerText = "Остановиться и ждать зеленого сигнала",
            IsCorrect = true
        };

        var answer6 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[1].Id,
            AnswerText = "Проехать с осторожностью",
            IsCorrect = false
        };

        var answer7 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[1].Id,
            AnswerText = "Повернуть налево, если нет машин",
            IsCorrect = false
        };

        var answer8 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[1].Id,
            AnswerText = "Ускориться",
            IsCorrect = false
        };

        var answer9 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[2].Id,
            AnswerText = "Штраф и баллы на лицензию",
            IsCorrect = true
        };

        var answer10 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[2].Id,
            AnswerText = "Только штраф",
            IsCorrect = false
        };

        var answer11 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[2].Id,
            AnswerText = "Предупреждение",
            IsCorrect = false
        };

        var answer12 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[2].Id,
            AnswerText = "Без наказания",
            IsCorrect = false
        };

        var answer13 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[3].Id,
            AnswerText = "Остановиться и пропустить пешехода",
            IsCorrect = true
        };

        var answer14 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[3].Id,
            AnswerText = "Посигналить пешеходу",
            IsCorrect = false
        };

        var answer15 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[3].Id,
            AnswerText = "Ускориться, чтобы пройти перед пешеходом",
            IsCorrect = false
        };

        var answer16 = new Answer
        {
            Id = Guid.NewGuid(),
            QuestionId = questions[3].Id,
            AnswerText = "Игнорировать пешехода",
            IsCorrect = false
        };

        return new List<Answer>
        {
            answer1, answer2, answer3, answer4, answer5, answer6, answer7, answer8, answer9, answer10, answer11,
            answer12, answer13, answer14, answer15, answer16
        };
    }
}