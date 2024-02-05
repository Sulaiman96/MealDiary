import React, { ChangeEvent, SyntheticEvent, useState } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Navigationbar from "./components/navigationbar/navigationbar";
import Hero from "./components/Hero/hero";
import { BrowserRouter } from 'react-router-dom';
import MealList from './components/MealList/MealList';
import Search from './components/Search/Search';
import { searchMeal } from './api';
import { Meal } from './Types/meal';

function App() {
    const [search, setSearch] = useState<string>("");
    const [mealResult, setMealResult] = useState<Meal[]>([]);
    const [serverError, setServerError] = useState<string>("");

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value)
        console.log(e);
    }

    const onClickEvent = async (e: SyntheticEvent) => {
        const result = await searchMeal("Sushi Platter");
        console.log(result);
        if (typeof result === "string") {
            setServerError(result);
        } else if (Array.isArray(result.data)) {
            setMealResult(result.data);
        }
        console.log(setMealResult);
    }

    return (
        <BrowserRouter>
            <div className="App">
                <Navigationbar />
                <Hero />
                <Search onClickEvent={onClickEvent} search={search} handleChange={handleChange} />
                <MealList />
            </div>
        </BrowserRouter>
    );
}

export default App;
