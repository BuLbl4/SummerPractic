import Cookies from 'js-cookie';
import {loginSuccess, logout} from './authSlice';

const checkTokenAndDispatch = (dispatch) => {
    const token = Cookies.get('authToken');

    if (token) {
        try {
            if(token){
                const tokenData = JSON.parse(atob(token.split('.')[1]));
                console.log(tokenData, "Токен")
                if (tokenData && tokenData.Id && tokenData.Name && tokenData.Email) {
                    const id = tokenData.Id;
                    const name = tokenData.Name;
                    const email = tokenData.Email;
                    dispatch(loginSuccess({ id, name, email }));
                } else {
                    dispatch(logout());
                    console.error('Токен не содержит необходимых данных.');
                }

            } else {
                dispatch(logout());
                console.log("Net Tokena")

            }
        } catch (error) {
            console.error('Ошибка при парсинге токена:', error);
        }
    }
};

export default checkTokenAndDispatch;
