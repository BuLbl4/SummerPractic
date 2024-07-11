import {useState} from "react";
import axiosClient from "../../utils/axiosClient";
import ResetPassword from "./ResetPassword";

const SendCodePassword = ({email}) => {
    const codeType = "ResetPasswordCode";
    const [code, setCode] = useState("")
    const [message, setMessage] = useState("")
    const [request, setRequest] = useState(false)


    const handleSendCode = async (e) => {
        e.preventDefault();
        setMessage('');

        try {
            setRequest(true)
            const response = await axiosClient.post('/Auth/CodeCheck', {email, code, codeType });
            console.log("Проверить код");

            if (response && response.data && response.data.isSuccessfully) {
                setMessage(response.data.message);
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
                            <form onSubmit={handleSendCode}>
                                <div className="crs_log_wrap">
                                    <div className="crs_log__caption">
                                        <div className="rcs_log_124">
                                            <div className="Lpo09"><h4>Forgot password</h4></div>
                                            <div className="form-group">
                                                <label>Сheck your email and write the code </label>
                                                <input
                                                    type="text"
                                                    className="form-control"
                                                    placeholder="Code"
                                                    value={code}
                                                    onChange={(e) => setCode(e.target.value)}
                                                    required
                                                />
                                            </div>
                                            <div className="form-group">
                                                <button type="submit"
                                                        className="btn full-width btn-md theme-bg text-white">Send Code
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
            {request ? <ResetPassword email={email}/> : ""}
        </>
    );
};

export default SendCodePassword;