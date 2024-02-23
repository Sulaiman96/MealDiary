import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import { searchMeals } from './api';
import { RouterProvider } from 'react-router-dom';
import { router } from './Routes/Routes';

const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);

console.log(searchMeals());
root.render(
    <React.StrictMode>
        <RouterProvider router={router}></RouterProvider>
    </React.StrictMode>
);