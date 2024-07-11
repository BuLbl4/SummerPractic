import axiosClient from "../../utils/axiosClient";
import { useState } from "react";
import ConfirmEmailCode from "../Auth/ConfirmEmailCode";

const ConfirmEmail = ({ userInfo }) => {
    const [request, setRequest] = useState(false);
    const [isConfirmed, setIsConfirmed] = useState(false);
    const [isButtonDisabled, setIsButtonDisabled] = useState(false); // Новое состояние для управления кнопкой

    const handleConfirmEmail = async (e) => {
        e.preventDefault();
        setIsButtonDisabled(true); // Отключить кнопку после нажатия
        console.log(userInfo,"HUI")
        try {
            const response = await axiosClient.post("/Email/ConfirmEmailFromCode", {
                email: userInfo.email
            });

            console.log(response)

            if (response && response.data && response.data.isSuccessfully) {
                setRequest(true);
            } else {
                console.log("None");
            }
        } catch (error) {
            console.error("Ошибка:", error.response);
        }
    };

    return (
        <>
            {!isConfirmed && (
                <div className="col-xl-5 col-lg-6 col-md-12" style={{ marginTop: -30 }}>
                    <form onSubmit={handleConfirmEmail}>
                        <div className="form-group smalls">
                            <button className="btn theme-bg text-white" type="submit" disabled={isButtonDisabled}>
                                {isButtonDisabled ? "Processing..." : "Confirm Email"}
                            </button>
                        </div>
                    </form>
                </div>
            )}
            {request && !isConfirmed && (
                <ConfirmEmailCode
                    email={userInfo.email}
                    onSuccess={() => setIsConfirmed(true)}
                />
            )}
        </>
    );
};

export default ConfirmEmail;
