import '../../assets/css/styles.css';
import error from '../../assets/img/404.png'
import Menu from '../HomePage/Menu';

const ErrorPage = () => {
	return (

		<div id="main-wrapper">
			<Menu></Menu>
			<div className="clearfix"></div>
			<section className="error-wrap">
				<div className="container">
					<div className="row justify-content-center" style={{marginLeft : 100}}>
						<div className="col-lg-6 col-md-10">
							<div className="text-center">
								<img src={error} className="img-fluid" alt="" />
								<p>Maecenas quis consequat libero, a feugiat eros. Nunc ut lacinia tortor morbi ultricies laoreet ullamcorper phasellus semper</p>
								<a className="btn theme-bg text-white btn-md" href="/semfront/public">Back To Home</a>
							</div>
						</div>
					</div>
				</div>
			</section>
			
			<script src="../../assets/js/jquery.min.js"></script>
			<script src="../../assets/js/popper.min.js"></script>
			<script src="../../assets/js/bootstrap.min.js"></script>
			<script src="../../assets/js/select2.min.js"></script>
			<script src="../../assets/js/slick.js"></script>
			<script src="../../assets/js/moment.min.js"></script>
			<script src="../../assets/js/daterangepicker.js"></script>
			<script src="../../assets/js/summernote.min.js"></script>
			<script src="../../assets/js/metisMenu.min.js"></script>
			<script src="../../assets/js/custom.js"></script>
		</div>
	);
};

export default ErrorPage;


