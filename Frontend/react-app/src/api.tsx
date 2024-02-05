import axios from "axios"
import { User } from "./Types/user"
import { Meal } from "./Types/meal";

interface UserReponse {
    data: User[];
}

interface MealResponse {
    data: Meal[];
}

export const searchUser = async (user: string) => {
    try {
        const data = await axios.get<UserReponse>(
            `https://localhost:5001/api/User/${user}`
        );
        return data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
            return error.message;
        } else {
            console.log("unexpected error: ", error);
            return "An unexpected error has occured";
        }
    }
}

export const searchUsers = async () => {
    try {
        const data = await axios.get<UserReponse>(
            `https://localhost:5001/api/User`
        );
        return data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
            return error.message;
        } else {
            console.log("unexpected error: ", error);
            return "An unexpected error has occured";
        }
    }
}

export const searchMeals = async () => {
    try {
        const data = await axios.get<MealResponse>(
            `https://localhost:5001/api/Meal`
        );
        return data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
            return error.message;
        } else {
            console.log("unexpected error: ", error);
            return "An unexpected error has occured";
        }
    }
}

export const searchMeal = async (mealName: string) => {
    try {
        const data = await axios.get<MealResponse>(
            `https://localhost:5001/api/Meal/${mealName}`
        );
        return data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
            return error.message;
        } else {
            console.log("unexpected error: ", error);
            return "An unexpected error has occurred";
        }
    }
}