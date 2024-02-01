import React from 'react'
import "./Meal.css";

interface Props {
    mealName: string;
    restaurant: string;
    image: string;
    ingredients: string[];
    price: number;
}

const Meal = ({ mealName, restaurant, image, ingredients, price }: Props) => {
    return (
        <div className='meal'>
            <img
                src={image}
                alt=''
            />
            <div className='details'>
                <h2>{mealName}</h2>
                <p>{restaurant}</p>
            </div>
            <p className='info'>Ingredients: {ingredients.join(', ')}.</p>
            <p className='info'>{price} </p>
        </div>
    )
}

export default Meal