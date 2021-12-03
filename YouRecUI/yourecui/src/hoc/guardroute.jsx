import { useSelector } from 'react-redux';
import { Navigate, useLocation } from 'react-router-dom';

const GuardedRoute = ({ children }) => {
    let location = useLocation()
    let isLoggedIn = useSelector(store => store.isLoggedIn);

    return isLoggedIn ? (
        children
    ) : (
        <Navigate to="/SignIn" state={{ from: location }} />
    )
}

export default GuardedRoute;