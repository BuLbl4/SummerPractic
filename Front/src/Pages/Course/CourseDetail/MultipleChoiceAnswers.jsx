import React from 'react';

const MultipleChoiceAnswers = ({ answers, selectedAnswers, correctAnswers, incorrectAnswers, onAnswerSelect, isSubmitted }) => {
    return (
        <div>
            {answers.map(answer => {
                let textStyle = {};
                if (isSubmitted) {
                    if (correctAnswers.includes(answer.id)) {
                        textStyle = { color: 'green' };
                    } else if (incorrectAnswers.includes(answer.id)) {
                        textStyle = { color: 'red' };
                    }
                }
                return (
                    <div key={answer.id}>
                        <label>
                            <input
                                type="checkbox"
                                checked={selectedAnswers.includes(answer.id)}
                                onChange={() => onAnswerSelect(answer.id)}
                                disabled={isSubmitted}
                            />
                            <span style={textStyle}>{answer.answerText}</span>
                        </label>
                    </div>
                );
            })}
        </div>
    );
};

export default MultipleChoiceAnswers;
