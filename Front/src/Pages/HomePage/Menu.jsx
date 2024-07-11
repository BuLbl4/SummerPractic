import logo from '../../assets/img/logo.png';
import React, {useEffect, useState} from 'react';
import {Link, useLocation} from 'react-router-dom';
import ScrollToTopButton from "../AnotherPage/ScrollToTopButton";
import {useDispatch, useSelector} from "react-redux";
import Logout from "../Auth/Logout";
import checkTokenAndDispatch from "../../utils/checkTokenAndDispatch";
import axiosClient from "../../utils/axiosClient";

const Menu = () => {
    const [activeButton, setActiveButton] = useState(1);
    const location = useLocation();
    const user = useSelector(state => state.auth.user);
    const dispatch = useDispatch();
    const [name, setName] = useState("");


    useEffect(() => {
        checkTokenAndDispatch(dispatch);

    }, [dispatch]);

    useEffect(() => {
        if (user && user.id) {
            fetchData();
        }
    }, [user]);

    const fetchData = async () => {
        try {
            console.log("Запрос из меню на пользователя");
            const response = await axiosClient.get(`/EditProfile/GetUserById?Id=${user.id}`);
            console.log(response)
            if (response && response.data && response.data.isSuccessfully) {
                setName(response.data.name)
            }
        } catch (error) {
            console.log("error", error);
        }
    };
    useEffect(() => {
        switch (location.pathname) {
            case `/`:
                setActiveButton(1);
                break;
            case `/Tests`:
            case `/Tests/:name`:
                setActiveButton(2);
                break;
            case `/Profile`:
                setActiveButton(3);
                break;
            default:
                setActiveButton(1);
                break;
        }
    }, [location.pathname]);

    return (
        <div className="header header-light head-shadow">
            <div className="container">
                <nav id="navigation" className="navigation navigation-landscape">
                    <div className="nav-header">
                        <a className="nav-brand" href="/">
                            <img src={logo} className="logo" alt=""/>
                        </a>
                        <div className="nav-toggle"></div>
                    </div>
                    <div className="nav-menus-wrapper">
                        <ul className="nav-menu">
                            <li className={`${activeButton === 1 ? 'active' : ''}`}><a href="/">Home<span
                                className="submenu-indicator"></span></a></li>
                            <li className={`${activeButton === 2 ? 'active' : ''}`}><a href="/Tests">Tests<span
                                className="submenu-indicator"></span></a>
                            </li>
                            {user.id ?
                                <li className={`${activeButton === 3 ? 'active' : ''}`}><a href="/Profile">Profile<span
                                    className="submenu-indicator"></span></a>
                                </li>
                            : ""}


                        </ul>
                        {user && user.id ? (
                            <ul className="nav-menu nav-menu-social align-to-right">
                            <li>
                                <div className="btn-group account-drop">
                                        <span>{name}</span>
                                        <Link to={`/Profile`} className="crs_yuo12 btn btn-order-by-filt" style={{marginTop: 0}}
                                              data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        </Link>
                                    </div>
                                </li>
                                <li className="add-listing theme-bg">
                                    <Logout/>
                                </li>
                            </ul>
                        ) : (
                            <ul className="nav-menu nav-menu-social align-to-right">
                                <li>
                                    <a href="/Login" className="alio_green" data-toggle="modal" data-target="#login">
                                        <i className="fas fa-sign-in-alt mr-1"></i><span
                                        className="dn-lg">Sign In</span>
                                    </a>
                                </li>
                                <li className="add-listing theme-bg">
                                    <a href="/SignUp" className="text-white">Get Started</a>
                                </li>
                            </ul>
                        )}
                    </div>
                </nav>
            </div>
            <ScrollToTopButton/>
        </div>
    );
};

export default Menu;
