import React from 'react'
import Meal from '../Meal/Meal'
import './MealList.css';

interface Props { }

const MealList: React.FC<Props> = (props: Props): JSX.Element => {
    return (
        <div className='center-both-flexbox'>
            <Meal
                mealName='Egg Royal'
                restaurant='Lumi Cafe'
                image='https://images.unsplash.com/photo-1622532630744-d977c065c094?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'
                ingredients={['egg', 'sourdough', 'salmon', 'hollandaise sauce']}
                price={13.95}
            />
            <Meal
                mealName='English'
                restaurant='Bob Cafe'
                image='https://images.unsplash.com/photo-1524182732116-a3ad2034503c?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'
                ingredients={['egg', 'saussage', 'mushrooms', 'beans']}
                price={15.95}
            />
            <Meal
                mealName='Vegan Burger'
                restaurant='Everyman'
                image='https://images.unsplash.com/photo-1525059696034-4967a8e1dca2?q=80&w=1976&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'
                ingredients={['vegan patty', 'cheese', 'lettuce', 'tomato']}
                price={19.99}
            />
        </div>
    )
}

export default MealList