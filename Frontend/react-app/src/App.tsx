import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import "react-toastify/dist/ReactToastify.css";
import { Outlet } from 'react-router';
import Navigationbar from './Components/navigationbar/navigationbar';
import { UserProvider } from './Components/Context/useAuth';
import { ToastContainer } from 'react-toastify';

function App() {

    return (
        <div>
            <UserProvider>
                <Navigationbar />
                <ToastContainer />
                <Outlet />
            </UserProvider>
        </div>
    );
}

export default App;
