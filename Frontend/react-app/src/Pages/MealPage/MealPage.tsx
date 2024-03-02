import React, { ChangeEvent, SyntheticEvent, useState } from 'react'
import Search from '../../Components/Search/Search';
import MealList from '../../Components/MealList/MealList';
import "react-toastify/dist/ReactToastify.css";
import { searchMeal, searchMeals } from '../../api';
import { Meal } from '../../Types/meal';

interface Props { }

const MealPage = (props: Props) => {

    const [search, setSearch] = useState<string>("");
    const [mealCollectionValues, setMealCollectionValues] = useState<string[]>([]);
    const [mealResult, setMealResult] = useState<Meal[]>([]);
    const [serverError, setServerError] = useState<string>("");

    const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value)
        console.log(e);
    }

    const onMealcollectionCreate = (e: any) => {
        e.preventDefault();
        const updatedMealCollectionValues = [...mealCollectionValues, e.target[0].value];
        setMealCollectionValues(updatedMealCollectionValues);
    }

    const onSearchSubmit = async (e: SyntheticEvent) => {
        e.preventDefault();
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

    return <div className="h-screen flex items-center justify-center">
        <div className='border borde'>
            <Search onSearchSubmit={onSearchSubmit} search={search} handleSearchChange={handleSearchChange} />
            {serverError && <h1>{serverError}</h1>}
        </div>
        <MealList mealResult={mealResult} />
    </div>
}

export default MealPage