import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import {Provider} from 'react-redux';
import store from './utils/store';
import './index.css';
import HomePage from './Pages/HomePage/HomePage';
import Tests from './Pages/Course/Tests';
import ErrorPage from './Pages/AnotherPage/ErrorPage';
import CourseCard from "./Pages/Course/TestCard";
import Login from "./Pages/Auth/Login";
import ForgotPassword from "./Pages/Auth/ForgotPassword";
import SignUp from "./Pages/Auth/SignUp";
import TestInfo from "./Pages/Course/CourseDetail/TestInfo";
import Profile from "./Pages/Profile/Profile";
import TestCard from "./Pages/Course/TestCard";


const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
    <Provider store={store}>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/SignUp" element={<SignUp />} />
          <Route path="/Login" element={<Login />} />
          <Route path="/Forgot" element={<ForgotPassword />} />

          <Route path="/Tests" element={<Tests />} />
          <Route path="/Test/:id" element={<TestInfo />} />
          <Route path="/TestCard" element={<TestCard />} />
          <Route path="*" element={<ErrorPage />} />
          <Route path="/Profile" element={<Profile />} />
        </Routes>
      </BrowserRouter>
    </Provider>
);


