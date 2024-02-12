import React from 'react'
import MealCard from '../Meal/MealCard'
import './MealList.css';
import { Meal } from '../../Types/meal';
import { v4 as uuidv4 } from 'uuid';

interface Props {
    mealResult: Meal[];
}

const MealList: React.FC<Props> = ({ mealResult }: Props): JSX.Element => {
    return <>
        {mealResult.length > 0
            ? (
                mealResult.map((result) => {
                    return <MealCard id={result.name} key={uuidv4()} meal={result} />;
                })
            ) : (
                <h1>No Results</h1>
            )}
    </>;

}

export default MealList