import React from 'react'
import { Navigate, useLocation } from 'react-router';
import { useAuth } from '../Components/Context/useAuth';

type Props = { children: React.ReactNode };
//TODO - Try to write another protectedroute component that hides Login/Register pages once the user has logged in.
const ProtectedRoute = ({ children }: Props) => {
    const location = useLocation();
    const { isLoggedIn } = useAuth();
    return isLoggedIn() ? (<>{children}</>)
        : (
            <Navigate to={"/login"} state={{ from: location }} replace />
        )
}

export default ProtectedRoute