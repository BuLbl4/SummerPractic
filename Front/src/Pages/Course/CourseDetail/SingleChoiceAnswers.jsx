import React from "react";

const SingleChoiceAnswers = ({ answers, selectedAnswer, onAnswerSelect, isSubmitted, isCorrect }) => {
    return (
        <ul className="horizontal-list">
            {answers.map((answer, index) => (
                <li key={index} className={selectedAnswer === answer.id ? (isSubmitted ? (isCorrect ? 'selected correct' : 'selected incorrect') : 'selected') : ''}>
                    <label>
                        <input
                            type="radio"
                            name="single-choice"
                            value={answer.id}
                            checked={selectedAnswer === answer.id}
                            onChange={() => onAnswerSelect(answer.id)}
                            disabled={isSubmitted}
                        />
                        {answer.answerText}
                    </label>
                </li>
            ))}
        </ul>
    );
};

export default SingleChoiceAnswers;
