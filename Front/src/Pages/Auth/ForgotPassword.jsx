import {useEffect, useState} from "react";
import axiosClient from "../../utils/axiosClient";
import SendCodePassword from "./SendCodePassword";

const ForgotPassword = () => {
    const [email, setEmail] = useState('');
    const [message, setMessage] = useState('');
    const [request, setRequest] = useState(false)
    useEffect(() => {
    }, []);

    const handleForgotPassword = async (e) => {
        e.preventDefault();
        setMessage('');

        try {
                setRequest(true)
            const response = await axiosClient.post('/Auth/ForgotPassword', { email });
            console.log("Забыли пароль");

            if (response && response.data && response.data.isSuccessfully) {
                setMessage('An email has been sent with password reset instructions.');
            } else {
                setMessage('Failed to send reset instructions. Please try again.');
            }
        } catch (error) {
            console.error('Error:', error);
            setMessage('An error occurred. Please try again later.');
        }
    };
    return(
        <>
            <section>
                <div className="container">
                    <div className="row justify-content-center">

                        <div className="col-xl-7 col-lg-8 col-md-12 col-sm-12">
                            <form onSubmit={handleForgotPassword}>
                                <div className="crs_log_wrap">
                                    <div className="crs_log__thumb">
                                        <img src="https://via.placeholder.com/1920x1200" className="img-fluid" alt=""/>
                                    </div>
                                    <div className="crs_log__caption">
                                        <div className="rcs_log_123">
                                            <div className="rcs_ico"><i className="fas fa-lock"></i></div>
                                        </div>

                                        <div className="rcs_log_124">
                                            <div className="Lpo09"><h4>Forgot password</h4></div>
                                            <div className="form-group">
                                                <label>Enter Email</label>
                                                <input
                                                    type="email"
                                                    className="form-control"
                                                    placeholder="Email"
                                                    value={email}
                                                    onChange={(e) => setEmail(e.target.value)}
                                                    required
                                                />
                                            </div>
                                            <div className="form-group">
                                                <button type="submit"
                                                        className="btn full-width btn-md theme-bg text-white">Forgot
                                                    password
                                                </button>
                                                {message && <div className="form-group"><p>{message}</p></div>}
                                            </div>
                                        </div>
                                    </div>
                                    <div className="crs_log__footer d-flex justify-content-between">
                                        <div className="fhg_45"><p className="musrt">Don't have account? <a
                                            href="/SignUp" className="theme-cl">SignUp</a></p></div>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </section>
            {request ? <SendCodePassword email={email}/> : ""}
        </>
    );
};

export default ForgotPassword;