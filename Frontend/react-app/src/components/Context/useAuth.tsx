import { createContext, useEffect, useState } from "react";
import { UserProfile } from "../Models/user";
import { useNavigate } from "react-router";
import { loginAPI, registerAPI } from "../../Services/AuthService";
import { toast } from "react-toastify";
import React from "react";
import axios from "axios";

type UserContextType = {
    user: UserProfile | null;
    token: string | null;
    registerUser: (firstName: string, lastName: string, email: string, password: string) => void;
    loginUser: (email: string, password: string) => void;
    logout: () => void;
    isLoggedIn: () => boolean;
};

type Props = { children: React.ReactNode };

const UserContext = createContext<UserContextType>({} as UserContextType);

export const UserProvider = ({ children }: Props) => {
    const navigate = useNavigate();
    const [token, setToken] = useState<string | null>(null);
    const [user, setUser] = useState<UserProfile | null>(null);
    const [isReady, setIsReady] = useState(false);

    useEffect(() => {
        const user = localStorage.getItem("user");
        const token = localStorage.getItem("token");
        if (user && token) {
            setUser(JSON.parse(user));
            setToken(token);
            axios.defaults.headers.common["Authorization"] = "Bearer" + token;
        }
        setIsReady(true);
    }, [])

    const registerUser = async (firstName: string, lastName: string, email: string, password: string) => {
        await registerAPI(firstName, lastName, email, password).then((res) => {
            if (res) {
                localStorage.setItem("token", res?.data.token);
                const userObj = {
                    firstName: res?.data.firstName,
                    lastName: res?.data.lastName,
                    email: res?.data.email
                }

                localStorage.setItem("user", JSON.stringify(userObj));
                setToken(res?.data.token!);
                setUser(userObj!);
                toast.success("Register Success!");

                navigate("/");
            }
        })
            .catch((e) => toast.warning("Server error occured"));
    };

    const loginUser = async (email: string, password: string) => {
        await loginAPI(email, password).then((res) => {
            if (res) {
                localStorage.setItem("token", res?.data.token);
                const userObj = {
                    firstName: res?.data.firstName,
                    lastName: res?.data.lastName,
                    email: res?.data.email
                }

                localStorage.setItem("user", JSON.stringify(userObj));
                setToken(res?.data.token!);
                setUser(userObj!);
                toast.success("Login Success!");

                navigate("/meal");
            }
        })
            .catch((e) => toast.warning("Server error occured"));
    };

    const isLoggedIn = () => {
        return !!user;
    }

    const logout = () => {
        localStorage.removeItem("token");
        localStorage.removeItem("user");

        setUser(null);
        setToken("");
        navigate("/")
    }

    return (
        <UserContext.Provider value={{ loginUser, user, token, logout, isLoggedIn, registerUser }}>

            {isReady ? children : null}
        </UserContext.Provider>
    );
};

export const useAuth = () => React.useContext(UserContext);

