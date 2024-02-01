import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Navigationbar from "./components/navigationbar/navigationbar";
import Hero from "./components/hero/hero";
import { BrowserRouter } from 'react-router-dom';
import MealList from './components/MealList/MealList';

function App() {
    return (
        <BrowserRouter>
            <div className="App">
                <Navigationbar />
                <Hero />
                <MealList />
            </div>
        </BrowserRouter>
    );
}

export default App;
