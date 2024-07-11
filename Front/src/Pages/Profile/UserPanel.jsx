import React, {useState} from "react";

const UserPanel = ({setActiveComponent}) => {
    const [activeMenuItem, setActiveMenuItem] = useState('my-profile');

    const handleMenuItemClick = (menuItem) => {
        setActiveMenuItem(menuItem);
        setActiveComponent(menuItem)
    };
    return(
        <>
            <div className="d-navigation">
                <ul id="side-menu">
                    <li className={activeMenuItem === 'my-profile' ? 'active' : ''}>
                        <a onClick={() => handleMenuItemClick('my-profile')}>
                            My Profile
                        </a>
                    </li>

                    <li className="dropdown">
                        <a>
                            <i className="fas fa-shopping-basket"></i>Test
                            <span className="ti-angle-left"></span>
                        </a>
                        <ul className="nav nav-second-level">
                            <li className={activeMenuItem === 'my-course' ? 'active' : ''}>
                                <a onClick={() => handleMenuItemClick('my-course')}>
                                    <i className="fas fa-th"></i>My tests results
                                </a>
                            </li>
                            <li className={activeMenuItem === 'add-new-course-user' ? 'active' : ''}>
                                <a onClick={() => handleMenuItemClick('add-new-course-user')}>
                                    Add New test
                                </a>
                            </li>

                        </ul>
                    </li>

                </ul>
            </div>
        </>
    );
};
export default UserPanel;