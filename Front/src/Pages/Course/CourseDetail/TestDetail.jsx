import React, { useState } from "react";
import axiosClient from "../../../utils/axiosClient";
import SingleChoiceAnswers from "./SingleChoiceAnswers";
import MultipleChoiceAnswers from "./MultipleChoiceAnswers";
import { useSelector } from "react-redux";

const TestDetail = ({ question, onResultsSubmit }) => {
    const [selectedAnswers, setSelectedAnswers] = useState([]);
    const [submittedAnswers, setSubmittedAnswers] = useState({});
    const [correctAnswers, setCorrectAnswers] = useState([]);
    const [incorrectAnswers, setIncorrectAnswers] = useState([]);
    const [isAnswerSubmitted, setIsAnswerSubmitted] = useState(false);
    const user = useSelector(state => state.auth.user);
    const [score, setScore] = useState(0);

    const handleSingleAnswerSelect = (answerId) => {
        setSelectedAnswers([answerId]);
    };

    const handleMultipleAnswerSelect = (answerId) => {
        if (selectedAnswers.includes(answerId)) {
            setSelectedAnswers(selectedAnswers.filter(id => id !== answerId));
        } else {
            setSelectedAnswers([...selectedAnswers, answerId]);
        }
    };

    const handleSubmitSingleAnswer = async () => {
        try {
            const answerId = selectedAnswers[0];
            const response = await axiosClient.post('Result/CheckAnswer', {
                userId: user.id,
                questionId: question.id,
                answerId: answerId
            });

            if (response.data.message === "Correct") {
                setScore(prevScore => prevScore + 1);
            }

            setSubmittedAnswers({
                ...submittedAnswers,
                [question.id]: response.data.message === "Correct"
            });

            onResultsSubmit({
                questionId: question.id,
                isCorrect: response.data.message === "Correct"
            });

            setIsAnswerSubmitted(true);

        } catch (error) {
            console.error("Ошибка при отправке ответа:", error);
        }
    };

    const handleSubmitMultipleAnswers = async () => {
        try {
            console.log("User ID:", user.id);
            console.log("Question ID:", question.id);
            console.log("Selected Answers:", selectedAnswers);

            const response = await axiosClient.post('Result/CheckMultipleAnswers', {
                userId: user.id,
                questionId: question.id,
                answerId: selectedAnswers  // Убедитесь, что это соответствует ожиданиям вашего бекенда
            });

            console.log("Response:", response);

            const isCorrect = response.data.message === "Correct";
            const correctAnswers = response.data.correctAnswerIds || [];
            const incorrectAnswers = response.data.incorrectAnswerIds || [];

            console.log("isCorrect:", isCorrect);
            console.log("Correct Answers:", correctAnswers);
            console.log("Incorrect Answers:", incorrectAnswers);

            if (isCorrect) {
                setScore(prevScore => {
                    const newScore = prevScore + 1;
                    console.log("New Score:", newScore);
                    return newScore;
                });
            }

            setSubmittedAnswers(prevSubmittedAnswers => {
                const newSubmittedAnswers = {
                    ...prevSubmittedAnswers,
                    [question.id]: isCorrect
                };
                console.log("New Submitted Answers:", newSubmittedAnswers);
                return newSubmittedAnswers;
            });

            setCorrectAnswers(correctAnswers);
            setIncorrectAnswers(incorrectAnswers);

            onResultsSubmit({
                questionId: question.id,
                isCorrect: isCorrect
            });

            setIsAnswerSubmitted(true);
            console.log("Is Answer Submitted:", true);

        } catch (error) {
            console.error("Ошибка при отправке ответа:", error);
        }
    };

    const handleSubmit = () => {
        if (question.onlyOneAnswer) {
            handleSubmitSingleAnswer();
        } else {
            handleSubmitMultipleAnswers();
        }
    };

    return (
        <div className="tab-pane fade show active">
            <div className="edu_wraper">
                <h4 className="edu_title">Вопрос</h4>
                <p>{question.questionText}</p>
                {question.onlyOneAnswer ? (
                    <SingleChoiceAnswers
                        answers={question.answers}
                        selectedAnswer={selectedAnswers[0]}
                        onAnswerSelect={handleSingleAnswerSelect}
                        isSubmitted={isAnswerSubmitted}
                        isCorrect={submittedAnswers[question.id]}
                    />
                ) : (
                    <MultipleChoiceAnswers
                        answers={question.answers}
                        selectedAnswers={selectedAnswers}
                        correctAnswers={correctAnswers}
                        incorrectAnswers={incorrectAnswers}
                        onAnswerSelect={handleMultipleAnswerSelect}
                        isSubmitted={isAnswerSubmitted}
                        isCorrect={submittedAnswers[question.id]}
                    />
                )}
                {!isAnswerSubmitted && (
                    <button onClick={handleSubmit} style={{
                        backgroundColor: "#4CAF50",
                        border: "none",
                        color: "white",
                        padding: "8px 24px",
                        textAlign: "center",
                        textDecoration: "none",
                        display: "inline-block",
                        fontSize: "16px",
                        margin: "4px 2px",
                        cursor: "pointer",
                        borderRadius: "4px"
                    }}>
                        Отправить ответ
                    </button>
                )}
                {submittedAnswers[question.id] !== undefined && (
                    <div>
                        {submittedAnswers[question.id] ? (
                            <span style={{ color: 'green' }}>Правильно</span>
                        ) : (
                            <span style={{ color: 'red' }}>Неправильно</span>
                        )}
                    </div>
                )}
            </div>
        </div>
    );
};

export default TestDetail;
