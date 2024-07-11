import React from "react";
import {Link} from "react-router-dom";

const CourseCardSecondView = ({course}) => {

    return(
        <>

            <div className="col-xl-6 col-lg-6 col-md-6 col-sm-12">
                <div className="crs_grid shadow_none brd">
                    <div className="crs_grid_thumb">
                        <Link to={`/Course/${course.id}`}>
                            <img src={course.mainImage} style={{width: 550, height: 350}}
                                 className="img-fluid rounded" alt=""/>
                        </Link>

                        {course.premium ?  <div className="crs_locked_ico">
                            <i className="fa fa-money-bill-wave"></i>
                        </div> : ""}

                    </div>
                    <div className="crs_grid_caption">
                    <div className="crs_flex">
                            <div className="crs_fl_first">
                                <div className={course.categoryStyle}><span>{course.category}</span></div>
                            </div>
                            <div className="crs_fl_last">
                                <div className="crs_price"><h2><span
                                    className="currency">$</span><span
                                    className="theme-cl">{course.price}</span></h2></div>
                            </div>
                        </div>
                        <div className="crs_title"><h4>
                         {course.name}</h4></div>
                        <div className="crs_info_detail">
                            <ul>
                                <li><i className="fa fa-video text-success"></i><span>{course.video} Lectures</span>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div className="crs_grid_foot">
                        <div className="crs_flex">
                            <div className="crs_fl_first">
                                <Link to={`/Instructor/${course.instructorId}`}>
                                <div className="crs_tutor">
                                    <div className="crs_tutor_thumb">

                                            <img
                                                src={course.instructorImage}
                                                className="img-fluid circle" alt=""/>
                                    </div>
                                    <span style={{marginLeft: 20}}>{course.instructorName}</span>
                                </div>
                                        </Link>
                            </div>
                            <div className="crs_fl_last">
                                <div className="foot_list_info">
                                    <ul className="light">
                                        <li>
                                            <div className="elsio_ic"><i
                                                className="fa fa-user text-danger"></i>
                                            </div>
                                            <div className="elsio_tx">{course.userCount}</div>
                                        </li>
                                        <li>
                                            <div className="elsio_ic"><i
                                                className="fa fa-eye text-success"></i>
                                            </div>
                                            <div className="elsio_tx">{course.viewCount}</div>
                                        </li>
                                        <li>
                                            <div className="elsio_ic"><i
                                                className="fa fa-star text-warning"></i>
                                            </div>
                                            <div className="elsio_tx">{course.rating}</div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}

export default CourseCardSecondView;