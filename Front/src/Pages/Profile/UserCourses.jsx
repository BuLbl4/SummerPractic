import axiosClient from "../../utils/axiosClient";
import React, { useEffect, useState } from "react";
import CourseCard from "../Course/TestCard";

const UserCourses = ({ user }) => {
    const [results, setResults] = useState([]);
    const [tests, setTests] = useState([]);

    useEffect(() => {
        fetchSearchResults();
    }, []);

    const fetchSearchResults = async () => {
        try {
            const response = await axiosClient.get(`Result/GetUserResult?UserId=${user.id}`);
            if (response && response.data && response.data.isSuccessfully) {
                setResults(response.data.results);
                setTests(response.data.tests);
            }
        } catch (error) {
            console.error('Ошибка:', error.response);
        }
    };

    const getUniqueTests = (tests) => {
        const uniqueTests = [];
        const seenIds = new Set();

        for (const test of tests) {
            if (!seenIds.has(test.id)) {
                seenIds.add(test.id);
                uniqueTests.push(test);
            }
        }
        return uniqueTests;
    };

    const uniqueTests = getUniqueTests(tests);

    return (
        <div className="col-lg-9 col-md-9 col-sm-12" >
            <div className="row">
                {uniqueTests.map(test => {
                    const testResults = results.filter(result => result.testId === test.id);
                    return (
                        <div key={test.id}>
                            {test ? <CourseCard tests={test} /> : <div>Invalid test data</div>}
                            {testResults.map(result => (
                                <div key={result.id} style={{padding: 20}}>
                                    <span>Результат: {result.score}</span>
                                    <span> Дата завершения: {new Date(result.completedAt).toLocaleString()}</span>
                                </div>
                            ))}
                        </div>
                    );
                })}
            </div>
        </div>
    );
};

export default UserCourses;
