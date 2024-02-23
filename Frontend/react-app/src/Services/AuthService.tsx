import axios from "axios"
import { handleError } from "../Helpers/ErrorHandler";
import { UserProfileToken } from "../Components/Models/user";

const api = "https://localhost:5001/api/"

export const loginAPI = async (email: string, password: string) => {
    try {
        const data = await axios.post<UserProfileToken>(api + "account/login", {
            Email: email,
            Password: password
        });
        return data;
    }
    catch (error) {
        handleError(error);
    }
}

export const registerAPI = async (firstName: string, lastName: string, email: string, password: string) => {
    try {
        const data = await axios.post<UserProfileToken>(api + "account/register", {
            FirstName: firstName,
            lastName: lastName,
            Email: email,
            Password: password
        });
        return data;
    }
    catch (error) {
        handleError(error);
    }
}