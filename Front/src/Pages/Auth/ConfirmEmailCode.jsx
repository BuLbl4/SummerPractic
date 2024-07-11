import { useState } from "react";
import axiosClient from "../../utils/axiosClient";

const ConfirmEmailCode = ({ email, onSuccess }) => {
    const codeType = "ConfirmEmailCode";
    const [code, setCode] = useState("");
    const [message, setMessage] = useState("");

    const handleSendCode = async (e) => {
        e.preventDefault();
        setMessage('');

        try {
            const response = await axiosClient.post('/Auth/CodeCheck', { email, code, codeType });
            console.log("Запрос на ПРоверку кода");
            if (response && response.data && response.data.isSuccessfully) {
                setMessage(response.data.message);
                onSuccess(); // вызываем onSuccess при успешном выполнении
            } else {
                setMessage('Failed to send reset instructions. Please try again.');
            }
        } catch (error) {
            console.error('Error:', error);
            setMessage('An error occurred. Please try again later.');
        }
    };

    return (
        <div className="container" style={{ paddingBottom: 20 }}>
            <form onSubmit={handleSendCode}>
                <div className="crs_log_wrap">
                    <div className="crs_log__caption">
                        <div className="rcs_log_124">
                            <div className="Lpo09"><h4>Confirm Email</h4></div>
                            <div className="form-group">
                                <label>Check your email and write the code</label>
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
                                <button
                                    type="submit"
                                    className="btn full-width btn-md theme-bg text-white"
                                >
                                    Send Code
                                </button>
                                {message && <div className="form-group"><p>{message}</p></div>}
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    );
};

export default ConfirmEmailCode;
