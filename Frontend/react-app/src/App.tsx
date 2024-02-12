import React, { ChangeEvent, SyntheticEvent, useState } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Navigationbar from "./components/navigationbar/navigationbar";
import Hero from "./components/Hero/hero";
import { BrowserRouter } from 'react-router-dom';
import MealList from './components/MealList/MealList';
import Search from './components/Search/Search';
import { searchMeal, searchMeals } from './api';
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
        let result;
        search.length > 0
            ? result = await searchMeal(search)
            : result = await searchMeals();

        console.log(result);
        if (typeof result === "string") {
            setServerError(result);
        } else {
            const mealsData = Array.isArray(result.data) ? result.data : [result.data];
            setMealResult(mealsData);
        }
        console.log(setMealResult);
    }

    return (
        <BrowserRouter>
            <div className="App">
                <Navigationbar />
                <Hero />
                <Search onClickEvent={onClickEvent} search={search} handleChange={handleChange} />
                {serverError && <h1>{serverError}</h1>}
                <MealList mealResult={mealResult} />
            </div>
        </BrowserRouter>
    );
}

export default App;
