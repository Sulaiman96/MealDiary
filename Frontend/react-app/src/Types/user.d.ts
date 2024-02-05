import { Meal } from "./meal"

export interface User {
    name: string,
    mealCollections: MealCollection,
    meals: Meal
}

export interface MealCollection {
    name: string,
    createdOn: Date
}