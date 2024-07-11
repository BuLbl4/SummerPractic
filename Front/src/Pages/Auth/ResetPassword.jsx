import {useState} from "react";
import axiosClient from "../../utils/axiosClient";
import {useNavigate} from "react-router-dom";

const ResetPassword = ({email}) => {
    const [password, setPassword] = useState("")
    const [secondPassword, setSecondPassword] = useState("")
    const [message, setMessage] = useState("")
    const navigate = useNavigate()


    const handleSendCode = async (e) => {
        e.preventDefault();
        setMessage('');


        try {
            if(password === secondPassword){
                const response = await axiosClient.post('/Auth/ResetPassword', { password, email });
                console.log("Ресет пароля");

                if (response && response.data && response.data.isSuccessfully) {
                    setMessage('Done');
                    navigate('/Login');
                } else {
                    setMessage('Failed to send reset instructions. Please try again.');
                }
            } else {
                setMessage('Password mismatch')
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
                            <form onSubmit={handleSendCode}>
                                <div className="crs_log_wrap">
                                    <div className="crs_log__caption">
                                        <div className="rcs_log_124">
                                            <div className="Lpo09"><h4>Forgot password</h4></div>
                                            <div className="form-group">
                                                <input
                                                    type="password"
                                                    className="form-control"
                                                    placeholder="New password"
                                                    value={password}
                                                    onChange={(e) => setPassword(e.target.value)}
                                                    required
                                                />
                                            </div>

                                            <div className="form-group">
                                                <input
                                                    type="password"
                                                    className="form-control"
                                                    placeholder="New password"
                                                    value={secondPassword}
                                                    onChange={(e) => setSecondPassword(e.target.value)}
                                                    required
                                                />
                                            </div>
                                            <div className="form-group">
                                                <button type="submit"
                                                        className="btn full-width btn-md theme-bg text-white">New
                                                    Password
                                                </button>
                                                {message && <div className="form-group"><p>{message}</p></div>}
                                            </div>
                                        </div>
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

export default ResetPassword;