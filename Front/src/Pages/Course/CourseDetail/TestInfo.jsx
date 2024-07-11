import Menu from "../../HomePage/Menu";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import axiosClient from "../../../utils/axiosClient";
import Footer from "../../AnotherPage/Footer";
import { useSelector } from "react-redux";
import CourseHeader from "./CourseHeader";
import TestDetail from "./TestDetail";

const TestInfo = () => {
    const user = useSelector(state => state.auth.user);
    const { id } = useParams();

    const [test, setTest] = useState(null);
    const [testResults, setTestResults] = useState([]);
    const [correctAnswersCount, setCorrectAnswersCount] = useState(0);
    const [isTestSubmitted, setIsTestSubmitted] = useState(false);

    useEffect(() => {
        if (test === null) {
            getCourses();
        }
    }, [test]);

    const getCourses = async () => {
        try {
            console.log("Запрос на курс", id);

            const response = await axiosClient.get(`Test/GetTestById?Id=${id}`);
            console.log(response);
            if (response && response.data && response.data.isSuccessfully) {
                setTest(response.data);
            }
        } catch (error) {
            console.error('Ошибка:', error.response);
        }
    };

    const handleResultsSubmit = (result) => {
        setTestResults(prevResults => [
            ...prevResults,
            result
        ]);

        if (result.isCorrect) {
            setCorrectAnswersCount(prevCount => prevCount + 1);
        }
    };

    const handleFinishTest = async () => {
        try {
            const correctAnswersCount = testResults.filter(result => result.isCorrect).length;

            const response = await axiosClient.post('Result/AddUserAnswers', {
                userId: user.id,
                score: testResults.map(result => ({
                    questionId: result.questionId,
                    isCorrect: result.isCorrect
                })),
                testId: test.id,
                correctAnswersCount: correctAnswersCount
            });
            console.log("Результаты теста отправлены на сервер:", response.data);
            setIsTestSubmitted(true);

        } catch (error) {
            console.error("Ошибка при отправке результатов теста:", error);
        }
    };

    if (test !== null) {
        return (
            <div id="main-wrapper">
                <Menu />
                <div className="clearfix"></div>
                <CourseHeader test={test}></CourseHeader>
                <section className="gray pt-5" style={{ flexDirection: "row" }}>
                    <div className="container">
                        <div className="row">
                            <div className="col-lg-8 col-md-12 order-lg-first">
                                <div className="tab_box_info mt-4">
                                    {test.questions.map(question => (
                                        <TestDetail
                                            key={question.id}
                                            question={question}
                                            onResultsSubmit={handleResultsSubmit}
                                        />
                                    ))}
                                </div>
                            </div>
                        </div>
                        <div style={{ textAlign: 'center', marginTop: '20px' }}>
                            {user.id ? (
                                !isTestSubmitted ? (
                                    <div>
                                        <div style={{ marginBottom: '10px' }}>
                                            Правильных ответов: {correctAnswersCount}
                                        </div>
                                        <button
                                            style={{
                                                backgroundColor: "#4CAF50",
                                                border: "none",
                                                color: "white",
                                                padding: "15px 32px",
                                                textAlign: "center",
                                                textDecoration: "none",
                                                display: "inline-block",
                                                fontSize: "16px",
                                                margin: "4px 2px",
                                                cursor: "pointer",
                                                borderRadius: "4px"
                                            }}
                                            onClick={handleFinishTest}
                                        >
                                            Завершить тест и отправить результаты
                                        </button>
                                    </div>
                                ) : (
                                    <div>Тест отправлен, спасибо!</div>
                                )
                            ) : (
                                "login pls"
                            )}
                        </div>
                    </div>
                </section>
                <Footer />
            </div>
        );
    } else {
        return null;
    }
};

export default TestInfo;
