import main from '../../assets/img/side-2.png'
import '../../assets/css/styles.css';
import Menu from './Menu';
import Footer from "../AnotherPage/Footer";
const HomePage = () => {
    return (
        <>
            <div id="main-wrapper">
                <Menu/>
                <div className="clearfix"></div>
                <div className="hero_banner image-cover image_bottom h4_bg">
                    <div className="container">
                        <div className="row align-items-center">
                            <div className="col-lg-6 col-md-6 col-sm-12">
                                <div className="simple-search-wrap text-left">
                                    <div className="hero_search-2">
                                        <h1 className="banner_title mb-4">Find the most exciting online cources</h1>
                                        <p className="font-lg mb-4">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore.</p>
                                    </div>
                                </div>
                            </div>
                            <div className="col-lg-6 col-md-6 col-sm-12">
                                <div className="side_block">
                                    <img src={main} className="img-fluid" alt="" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="clearfix"></div>

                <Footer></Footer>

                <div className="clearfix"></div>
            </div>
        </>
    );
};

export default HomePage;