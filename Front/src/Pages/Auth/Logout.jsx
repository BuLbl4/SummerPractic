import React from 'react';
import { useDispatch } from 'react-redux';
import { logout } from '../../utils/authSlice';
import { useNavigate } from "react-router-dom";
import Cookies from 'js-cookie';

const Logout = () => {
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const handleLogout = () => {
        dispatch(logout());
        Cookies.remove('authToken');
        navigate("/");
    };

    return (
        <>
            <ul className="nav-menu nav-menu-social align-to-right">
                <li>
                    <a  onClick={handleLogout} className="alio_green" data-toggle="modal" data-target="#login">
                        <i className="fas fa-sign-in-alt mr-1"></i><span className="dn-lg">Log Out</span>
                    </a>
                </li>
            </ul>
        </>
    );
};

export default Logout;
