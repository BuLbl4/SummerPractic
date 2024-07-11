import { configureStore } from '@reduxjs/toolkit';
import authReducer from './authSlice'; // Ваш срез авторизации
import profileReducer from './profileSlice'

const store = configureStore({
    reducer: {
        auth: authReducer,
        profile : profileReducer,
    },
});

export default store;