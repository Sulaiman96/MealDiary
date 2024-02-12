import React from 'react'
import "./MealCard.css";
import { Meal } from '../../Types/meal';

interface Props {
    id: string;
    meal: Meal;
}

const MealCard: React.FC<Props> = ({ id, meal: mealResult }: Props): JSX.Element => {
    return (
        <div className='meal'>
            <img
                src={mealResult.photos.find(photo => photo.isMain === true)?.url}
                alt='meal photo'
            />
            <div className='details'>
                <h2>{mealResult.name}</h2>
                <p>{mealResult.location}</p>
            </div>
            <p className='info'>Ingredients: {mealResult.ingredients.map(ingredient => ingredient.name).join(', ')}.</p>
            <p className='info'>{mealResult.price} </p>
        </div>
    )
}

export default MealCard