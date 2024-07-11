import axiosClient from './../../utils/axiosClient';
import Cookies from "js-cookie";
import {useNavigate} from "react-router-dom";
import {useState} from "react";

const Login = () => {
    const [message, setMessage] = useState(null); // Состояние для хранения сообщения
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        try {
            e.preventDefault();

            setMessage(null); // Сбрасываем сообщение перед новой попыткой логина
            const email = e.target.elements.email.value;
            const password = e.target.elements.password.value;

            const response = await axiosClient.post('/Login/Login', {
                email,
                password
            });
            if (response && response.data && response.data.isSuccessfully) {
                Cookies.set('authToken', response.data.token, { expires: 6 / 24 });
                setMessage({ type: "success", text: "Login successful" });
                navigate('/');
            } else {
                setMessage({ type: "error", text: "Invalid email or password. Please try again." });
            }

            console.log("Login");
        } catch (error) {
            console.error('Ошибка:', error.response);
            setMessage({ type: "error", text: "An error occurred. Please try again later." });
        }
    };

    return (
        <>
            <section>
                <div className="container">
                    <div className="row justify-content-center">

                        <div className="col-xl-7 col-lg-8 col-md-12 col-sm-12">
                            <div className="crs_log_wrap">
                                <div className="crs_log__thumb">
                                    <img src="https://via.placeholder.com/1920x1200" className="img-fluid" alt=""/>
                                </div>
                                <div className="crs_log__caption">
                                    <div className="rcs_log_123">
                                        <div className="rcs_ico"><i className="fas fa-lock"></i></div>
                                    </div>
                                    <div className="rcs_log_124">
                                        <div className="Lpo09"><h4>Login Your Account</h4></div>
                                        <form onSubmit={handleLogin}>

                                            <div className="form-group">
                                                <label>Email</label>
                                                <input type="text" name="email" className="form-control"
                                                       placeholder="Email"/>
                                            </div>
                                            <div className="form-group">
                                                <label>Password</label>
                                                <input type="password" name="password" className="form-control"
                                                       placeholder="Password"/>
                                            </div>
                                            <div className="form-group">
                                                <button type="submit"
                                                        className="btn full-width btn-md theme-bg text-white">Login
                                                </button>
                                            </div>
                                        </form>
                                        {message && (
                                            <p className={`text-${message.type === "success" ? "success" : "danger"}`}>
                                                {message.text}
                                            </p>
                                        )}
                                    </div>
                                    {/*<div className="rcs_log_125">*/}
                                    {/*    <span>Or Login with Social Info</span>*/}
                                    {/*</div>*/}
                                    {/*<div className="rcs_log_126">*/}
                                    {/*    <ul className="social_log_45 row">*/}
                                    {/*        <li className="col-xl-4 col-lg-4 col-md-4 col-4"><a*/}
                                    {/*            className="sl_btn"><i*/}
                                    {/*            className="ti-facebook text-info"></i>Facebook</a></li>*/}
                                    {/*        <li className="col-xl-4 col-lg-4 col-md-4 col-4"><a*/}
                                    {/*            className="sl_btn"><i*/}
                                    {/*            className="ti-google text-danger"></i>Google</a></li>*/}
                                    {/*        <li className="col-xl-4 col-lg-4 col-md-4 col-4"><a*/}
                                    {/*            className="sl_btn"><i*/}
                                    {/*            className="ti-twitter theme-cl"></i>Twitter</a></li>*/}
                                    {/*    </ul>*/}
                                    {/*</div>*/}
                                </div>
                                <div className="crs_log__footer d-flex justify-content-between">
                                    <div className="fhg_45"><p className="musrt">Don't have account? <a
                                        href="/SignUp" className="theme-cl">SignUp</a></p></div>
                                    <div className="fhg_45"><p className="musrt"><a href="/Forgot"
                                                                                    className="text-danger">Forgot
                                        Password?</a></p></div>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </section>
        </>
    );
};

export default Login;
