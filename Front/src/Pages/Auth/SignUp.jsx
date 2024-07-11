import axiosClient from "../../utils/axiosClient";
import { useDispatch } from "react-redux";
import { loginFailure, loginStart } from "../../utils/authSlice";
import { useNavigate } from "react-router-dom";
import Cookies from 'js-cookie';
import { useState, useEffect } from "react";

const SignUp = () => {
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const [message, setMessage] = useState("");
    const [errorMessage, setErrorMessage] = useState("");

    const handleSignUp = async (e) => {
        e.preventDefault();
        dispatch(loginStart());
        console.log("Регистрация");
        const firstName = e.target.elements.firstName.value;
        const lastName = e.target.elements.lastName.value;
        const email = e.target.elements.email.value;
        const password = e.target.elements.password.value;
        setMessage("");
        setErrorMessage("");

        try {
            const response = await axiosClient.post('/Auth/Authentication', {
                firstName,
                lastName,
                email,
                password
            });

            if (response && response.data && response.data.isSuccessfully) {
                Cookies.set('authToken', response.data.token, { expires: 6 / 24 });
                setMessage("Registration successful");
                navigate('/');
            } else {
                setErrorMessage("Registration failed. Please try again.");
            }
        } catch (error) {
            const errorMsg = error.response?.data?.errors || 'An error occurred';
            dispatch(loginFailure(errorMsg));
            setErrorMessage(errorMsg);
        }
    };

    useEffect(() => {
        if (errorMessage) {
            const timer = setTimeout(() => {
                setErrorMessage("");
            }, 5000);
            return () => clearTimeout(timer);
        }
    }, [errorMessage]);

    return (
        <>
            <section>
                <div className="container">
                    <div className="row justify-content-center">
                        <div className="col-xl-7 col-lg-8 col-md-12 col-sm-12">
                            <form onSubmit={handleSignUp}>
                                <div className="crs_log_wrap">
                                    <div className="crs_log__thumb">
                                        <img src="https://via.placeholder.com/1920x1200" className="img-fluid" alt="" />
                                    </div>
                                    <div className="crs_log__caption">
                                        <div className="rcs_log_123">
                                            <div className="rcs_ico"><i className="fas fa-user"></i></div>
                                        </div>
                                        <div className="rcs_log_124">
                                            <div className="Lpo09"><h4>Sign Up</h4></div>
                                            <div className="form-group row mb-0">
                                                <div className="col-xl-6 col-lg-12 col-md-12 col-sm-12">
                                                    <div className="form-group">
                                                        <label>First Name</label>
                                                        <input type="text" name="firstName" className="form-control" placeholder="First Name" required/>
                                                    </div>
                                                </div>
                                                <div className="col-xl-6 col-lg-12 col-md-12 col-sm-12">
                                                    <div className="form-group">
                                                        <label>Last Name</label>
                                                        <input type="text" name="lastName" className="form-control" placeholder="Last Name" required/>
                                                    </div>
                                                </div>
                                            </div>
                                            <div className="form-group">
                                                <label>Email</label>
                                                <input type="text" name="email" className="form-control" placeholder="example@gmail.com" required/>
                                            </div>
                                            <div className="form-group">
                                                <label>Password</label>
                                                <input type="password" className="form-control" name="password" required
                                                       placeholder="Password" />
                                            </div>
                                            <div className="form-group">
                                                <button type="submit" className="btn full-width btn-md theme-bg text-white">Sign Up</button>
                                            </div>
                                            {message && <p className="text-success">{message}</p>}
                                            {errorMessage && <p className="text-danger">{errorMessage}</p>}
                                        </div>
                                    </div>
                                    <div className="crs_log__footer d-flex justify-content-between">
                                        <div className="fhg_45"><p className="musrt">Already have account? <a href="/Login" className="theme-cl">Login</a></p></div>
                                        <div className="fhg_45"><p className="musrt"><a href="/Forgot" className="text-danger">Forgot Password?</a></p></div>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </section>
        </>
    );
};

export default SignUp;
