import React from "react";

const TestCard = ({tests}) => {
    return (
        <>
            <a href={`/Test/${tests.id}`}
               className="crs_title_link">
                <div className="col-xl-4 col-lg-4 col-md-6 col-sm-12">
                    <div className="crs_grid shadow_none brd">

                        <div className="crs_grid_caption">

                            <div className="crs_title">
                                <h5>
                                    {tests.serialNumber}
                                </h5>
                            </div>

                        </div>
                    </div>
                </div>
            </a>
        </>
    );
};

export default TestCard;