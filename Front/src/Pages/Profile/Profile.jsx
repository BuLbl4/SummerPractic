import Menu from "../HomePage/Menu";
import ProfileMenu from "./ProfileMenu";
import FooterSecond from "../AnotherPage/FooterSecond";
import Footer from "../AnotherPage/Footer";
import axiosClient from "../../utils/axiosClient";
import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import ProfileEditContainer from "./ProfileEditContainer";
import UserCourses from "./UserCourses";
import AddNewCourseUser from "./AddNewCourseUser";

const Profile = () => {
    const user = useSelector(state => state.auth.user);
    const [userInfo, setUserInfo] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [activeComponent, setActiveComponent] = useState('my-profile');

    useEffect(() => {
        if (user && user.id) {
            fetchData();
        } else {
            setLoading(false);
        }
    }, [user]);

    const fetchData = async () => {
        try {
            const response = await axiosClient.get(`EditProfile/GetUserById?Id=${user.id}`);
            if (response && response.data && response.data.isSuccessfully) {
                setUserInfo(response.data);
            } else {
                setError("Не удалось загрузить данные пользователя");
            }
        } catch (error) {
            setError('Ошибка: ' + (error.response ? error.response.data.message : error.message));
        } finally {
            setLoading(false);
        }
    };

    const handleComponentChange = (componentName) => {
        setActiveComponent(componentName);
    };

    if (loading) {
        return <div>Загрузка...</div>;
    }

    if (error) {
        return <div>{error}</div>;
    }
    return (
        <>
            <div id="main-wrapper">
                <Menu />
                <div className="clearfix"></div>
                <section className="gray pt-4">
                    <div className="container-fluid">
                        <div className="row">
                            {userInfo && <ProfileMenu userInfo={userInfo} setActiveComponent={handleComponentChange} />}
                            {activeComponent === 'my-profile' && <ProfileEditContainer userInfo={userInfo}/>}
                            {activeComponent === 'my-course' && <UserCourses user={userInfo.userInfo}/>}
                            {activeComponent === 'add-new-course-user' && <AddNewCourseUser userInfo={userInfo}/>}
                        </div>
                    </div>
                </section>
                <FooterSecond />
                <Footer />
            </div>
        </>
    );
};

export default Profile;
