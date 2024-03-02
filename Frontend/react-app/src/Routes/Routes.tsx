import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage/HomePage";
import AboutPage from "../Pages/AboutPage/AboutPage";
import ExplorePage from "../Pages/ExplorePage/ExplorePage";
import RegisterPage from "../Pages/RegisterPage/RegisterPage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import MealPage from "../Pages/MealPage/MealPage";
import MealDetailPage from "../Pages/MealDetailPage/MealDetailPage";
import PricingPage from "../Pages/PricingPage/PricingPage";
import ProtectedRoute from "./ProtectedRoute";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            { path: "", element: <HomePage /> },
            { path: "about", element: <AboutPage /> },
            { path: "explore", element: <ExplorePage /> },
            { path: "login", element: <LoginPage /> },
            { path: "register", element: <RegisterPage /> },
            { path: "meal", element: <ProtectedRoute><MealDetailPage /></ProtectedRoute> },
            { path: "meal/:meal", element: <ProtectedRoute><MealDetailPage /></ProtectedRoute> },
            { path: "pricing", element: <PricingPage /> }
        ]
    }
])