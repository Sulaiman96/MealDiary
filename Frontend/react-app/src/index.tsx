import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import { searchMeals } from './api';

const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);

console.log(searchMeals());
root.render(
    <React.StrictMode>
        <App />
    </React.StrictMode>
);