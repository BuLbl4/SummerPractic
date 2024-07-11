import React from "react";

const Footer = () => {

    return(
        <>
            <footer className="dark-footer skin-dark-footer style-2">
                <div className="footer-middle">
                    <div className="container">
                        <div className="row">

                            <div className="col-lg-5 col-md-5">
                                <div className="footer_widget">
                                    <img src="../../assets/img/logo-light.png" className="img-footer small mb-2"
                                         alt=""/>
                                    <h4 className="extream mb-3">Do you need help with<br/>anything?</h4>
                                    <p>Receive updates, hot deals, tutorials, discounts sent straignt in your inbox
                                        every month</p>
                                    <div className="foot-news-last">
                                        <div className="input-group">
                                            <input type="text" className="form-control"
                                                   placeholder="Email Address"/>
                                            <div className="input-group-append">
                                                <button type="button"
                                                        className="input-group-text theme-bg b-0 text-light">Subscribe
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div className="col-lg-6 col-md-7 ml-auto">
                                <div className="row">

                                    <div className="col-lg-4 col-md-4">
                                        <div className="footer_widget">
                                            <h4 className="widget_title">Layouts</h4>
                                            <ul className="footer-menu">
                                                <li><a href="#">Home Page</a></li>
                                                <li><a href="#">About Page</a></li>
                                                <li><a href="#">Service Page</a></li>
                                                <li><a href="#">Property Page</a></li>
                                                <li><a href="#">Contact Page</a></li>
                                                <li><a href="#">Single Blog</a></li>
                                            </ul>
                                        </div>
                                    </div>

                                    <div className="col-lg-4 col-md-4">
                                        <div className="footer_widget">
                                            <h4 className="widget_title">All Sections</h4>
                                            <ul className="footer-menu">
                                                <li><a href="#">Headers<span className="new">New</span></a></li>
                                                <li><a href="#">Features</a></li>
                                                <li><a href="#">Attractive<span className="new">New</span></a></li>
                                                <li><a href="#">Testimonials</a></li>
                                                <li><a href="#">Videos</a></li>
                                                <li><a href="#">Footers</a></li>
                                            </ul>
                                        </div>
                                    </div>

                                    <div className="col-lg-4 col-md-4">
                                        <div className="footer_widget">
                                            <h4 className="widget_title">Company</h4>
                                            <ul className="footer-menu">
                                                <li><a href="#">About</a></li>
                                                <li><a href="#">Blog</a></li>
                                                <li><a href="#">Pricing</a></li>
                                                <li><a href="#">Affiliate</a></li>
                                                <li><a href="#">Login</a></li>
                                                <li><a href="#">Changelog<span className="update">Update</span></a>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <a id="back2Top" className="top-scroll" title="Back to top" href="#"><i className="ti-arrow-up"></i></a>

            </footer>

            <div className="modal fade" id="login" tabIndex="-1" role="dialog" aria-labelledby="loginmodal"
                 aria-hidden="true">
                <div className="modal-dialog modal-xl login-pop-form" role="document">
                    <div className="modal-content overli" id="loginmodal">
                        <div className="modal-header">
                            <h5 className="modal-title">Login Your Account</h5>
                            <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true"><i className="fas fa-times-circle"></i></span>
                            </button>
                        </div>
                        <div className="modal-body">
                            <div className="login-form">
                            </div>
                        </div>
                        <div className="crs_log__footer d-flex justify-content-between mt-0">
                            <div className="fhg_45"><p className="musrt">Don't have account? <a href="signup.html"
                                                                                                className="theme-cl">SignUp</a>
                            </p></div>
                            <div className="fhg_45"><p className="musrt"><a href="forgot.html"
                                                                            className="text-danger">Forgot
                                Password?</a></p></div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
};

export default Footer;