import React, { useState } from 'react';
import axiosClient from "../../../utils/axiosClient";

const QuestionForm = ({ courseId }) => {
    const [formData, setFormData] = useState({
        question: '',
        options: [
            { text: '', isChecked: false },
            { text: '', isChecked: false },
            { text: '', isChecked: false },
            { text: '', isChecked: false }
        ],
    });

    const [questionType, setQuestionType] = useState('single');
    const [message, setMessage] = useState(null);
    const [isSubmitting, setIsSubmitting] = useState(false);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    const handleOptionChange = (index) => {
        if (questionType === 'single') {
            const updatedOptions = formData.options.map((option, i) => ({
                ...option,
                isChecked: i === index
            }));
            setFormData({
                ...formData,
                options: updatedOptions,
            });
        } else {
            const updatedOptions = [...formData.options];
            updatedOptions[index] = {
                ...updatedOptions[index],
                isChecked: !updatedOptions[index].isChecked,
            };
            setFormData({
                ...formData,
                options: updatedOptions,
            });
        }
    };

    const handleOptionTextChange = (index, value) => {
        const updatedOptions = [...formData.options];
        updatedOptions[index] = {
            ...updatedOptions[index],
            text: value,
        };
        setFormData({
            ...formData,
            options: updatedOptions,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setIsSubmitting(true);
        setMessage(null);

        // Check if there is exactly one correct answer selected in case of multiple type question
        if (questionType === 'multiple' && formData.options.filter(option => option.isChecked).length !== 1) {
            setMessage({ type: 'error', text: 'Please select exactly one correct answer for multiple choice questions.' });
            setIsSubmitting(false);
            return;
        }

        const dataToSend = {
            testId: courseId,
            question: formData.question,
            options: formData.options.map(option => option.text),
            correctAnswers: formData.options.filter(option => option.isChecked).map(option => option.text),
            questionType,
        };

        try {
            const response = await axiosClient.post('Question/CreateQuestionAndAnswer', dataToSend);
            console.log('Server response:', response.data);

            setFormData({
                question: '',
                options: [
                    { text: '', isChecked: false },
                    { text: '', isChecked: false },
                    { text: '', isChecked: false },
                    { text: '', isChecked: false }
                ],
            });
            setMessage({ type: 'success', text: 'Question submitted successfully!' });
        } catch (error) {
            console.error('Error submitting question:', error);
            setMessage({ type: 'error', text: 'Error submitting question. Please try again.' });
        } finally {
            setIsSubmitting(false);
        }
    };

    return (
        <div>
            <h3>Question Form for Test ID: {courseId}</h3>
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label>Question</label>
                    <input
                        type="text"
                        name="question"
                        className="form-control"
                        value={formData.question}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Options</label>
                    {formData.options.map((option, index) => (
                        <div key={index}>
                            <input
                                type={questionType === 'single' ? 'radio' : 'checkbox'}
                                className="form-check-input"
                                name={`option${index}`}
                                checked={option.isChecked}
                                onChange={() => handleOptionChange(index)}
                                required={!questionType === 'multiple'} // Требование выбора только для одного ответа в случае single
                            />
                            <input
                                type="text"
                                className="form-control"
                                value={option.text}
                                onChange={(e) => handleOptionTextChange(index, e.target.value)}
                                required
                            />
                        </div>
                    ))}
                </div>
                <div className="form-group">
                    <label>Question Type</label>
                    <div>
                        <label>
                            <input
                                type="radio"
                                value="single"
                                checked={questionType === 'single'}
                                onChange={() => setQuestionType('single')}
                            />
                            Single Correct Answer
                        </label>
                    </div>
                    <div>
                        <label>
                            <input
                                type="radio"
                                value="multiple"
                                checked={questionType === 'multiple'}
                                onChange={() => setQuestionType('multiple')}
                            />
                            Multiple Correct Answers
                        </label>
                    </div>
                </div>
                <button type="submit" className="btn btn-primary" disabled={isSubmitting}>
                    {isSubmitting ? 'Submitting...' : 'Submit Question'}
                </button>
            </form>
            {message && (
                <div className={`alert ${message.type === 'success' ? 'alert-success' : 'alert-danger'}`} role="alert">
                    {message.text}
                </div>
            )}
        </div>
    );
};

export default QuestionForm;
