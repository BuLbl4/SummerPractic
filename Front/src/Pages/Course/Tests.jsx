import Menu from '../HomePage/Menu';
import Footer from "../AnotherPage/Footer";
import {useEffect, useState} from "react";
import axiosClient from "../../utils/axiosClient";
import {useSelector} from "react-redux";
import TestCard from "./TestCard";
import {useNavigate} from "react-router-dom";

const Tests = () => {
    const user = useSelector(state => state.auth.user);
    const [tests, setTests] = useState([]);
    const navigate = useNavigate()

    useEffect(() => {
        fetchData();

    }, [user]);

    const fetchData = async () => {
        try {
            const response = await axiosClient.get(`/Test/GetAllTests`);
            console.log(response);
            if (response && response.data && response.data.isSuccessfully) {
                setTests(response.data.tests);
            }
        } catch (error) {
            console.log("error", error);
        }
    };

    const handleButtonClick = async () => {
        try {
            const response = await axiosClient.get(`/Test/GetRandomTest`);
            console.log(response);
            if (response && response.data && response.data.isSuccessfully) {
                console.log("Заебумба")

                navigate(`/Test/${response.data.id}`)
            }
        } catch (error) {
            console.log("error", error);
        }
    };

    return (
        <>
            <div id="main-wrapper">
                <Menu />
                <section className="gray">
                    <div className="container" style={{display: "flex", flexDirection: "row"}}>
                        {tests.map(test => (
                            <TestCard key={test.id} tests={test}></TestCard>
                        ))}

                    </div>
                    <button onClick={handleButtonClick} style={{marginLeft: 200}}>Random tests</button>
                </section>
                <Footer/>
            </div>
        </>
    );
};

export default Tests;
