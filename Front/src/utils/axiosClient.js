import axios from 'axios';


const axiosClient = axios.create({
    baseURL: 'http://localhost:5009/',
});

export default axiosClient;