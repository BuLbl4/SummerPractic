import { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import axiosClient from "../../utils/axiosClient";

const ProfileResetPassword = () => {
    const user = useSelector(state => state.auth.user);

    const [formData, setFormData] = useState({
        currentPassword: "",
        newPassword: "",
        confirmPassword: "",
        UserId: null
    });
    const [message, setMessage] = useState(null);

    useEffect(() => {
        setFormData(prevState => ({
            ...prevState,
            UserId: user.id
        }));
    }, [user]);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    const handleEditPassword = async (e) => {
        e.preventDefault();
        try {
            if (formData.confirmPassword === formData.newPassword) {
                const response = await axiosClient.post("/EditProfile/EditPassword", formData);
                if (response && response.data && response.data.isSuccessfully) {
                    setMessage({ type: "success", text: "Password updated successfully" });
                } else {
                    setMessage({ type: "error", text: "Failed to update password" });
                }
            } else {
                setMessage({ type: "error", text: "Passwords do not match" });
            }
        } catch (error) {
            console.error("Ошибка:", error.response);
            setMessage({ type: "error", text: "An error occurred while updating the password" });
        }
    };

    return (
        <>
            <div className="col-xl-5 col-lg-6 col-md-12">
                <div className="dashboard_wrap">
                    <div className="row justify-content-center">
                        <div className="col-xl-12 col-lg-12 col-md-12">
                            <form onSubmit={handleEditPassword}>
                                <div className="form-group smalls">
                                    <label>Current Password</label>
                                    <input type="password" className="form-control"
                                           name="currentPassword"
                                           value={formData.currentPassword}
                                           onChange={handleInputChange} required />
                                </div>
                                <div className="form-group smalls">
                                    <label>New Password</label>
                                    <input type="password" className="form-control"
                                           name="newPassword"
                                           value={formData.newPassword}
                                           onChange={handleInputChange} required />
                                </div>
                                <div className="form-group smalls">
                                    <label>Confirm Password</label>
                                    <input type="password" className="form-control"
                                           name="confirmPassword"
                                           value={formData.confirmPassword}
                                           onChange={handleInputChange} required />
                                </div>
                                <div className="form-group smalls">
                                    <button className="btn theme-bg text-white" type="submit">Save Change</button>
                                </div>
                            </form>
                            {message && (
                                <div className={`alert ${message.type === "success" ? "alert-success" : "alert-danger"}`} role="alert">
                                    {message.text}
                                </div>
                            )}
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
};

export default ProfileResetPassword;
