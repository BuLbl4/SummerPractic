import React from "react";

const CourseHeader = ({test}) => {
    const typeImg = {
        "Development": "crs_cates cl_1",
        "Design": "crs_cates cl_2",
        "Physics": "crs_cates cl_3",
        "Business": "crs_cates cl_4",
        "Banking": "crs_cates cl_5",
        "Finance": "crs_cates cl_6",
        "Fitness": "crs_cates cl_7",
    }
    return (
        <>
            <div className="ed_detail_head">
                <div className="container">
                    <div className="row align-items-center justify-content-between mb-2">

                        <div className="col-xl-7 col-lg-7 col-md-7 col-sm-12">
                            <div className="dlkio_452">
                                <div className="ed_detail_wrap">
                                    <div className={typeImg[0]}><span>{test.testName}</span></div>
                                    <div className="ed_header_caption">
                                        <h2 className="ed_title">{test.description}</h2>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
};
export default CourseHeader;