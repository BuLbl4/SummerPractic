import React, {useState} from "react";

const CourseDetailMenu = ({course}) => {
    const [activeTab, setActiveTab] = useState('overview');

    const handleTabChange = (tab) => {
        setActiveTab(tab);
    };

    return(
        <>
            <ul className="nav nav-pills mb-3 light" id="pills-tab" >
                <li className="nav-item">
                    <a className={`nav-link ${activeTab === 'overview' ? 'active' : ''}`}
                       onClick={() => handleTabChange('overview')}>Overview</a>
                </li>

                <li className="nav-item">
                    <a className={`nav-link ${activeTab === 'reviews' ? 'active' : ''}`}
                       onClick={() => handleTabChange('reviews')}>Reviews</a>
                </li>
            </ul>

        </>
    );
};

export default CourseDetailMenu;