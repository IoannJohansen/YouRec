import { useSelector } from "react-redux";
import { Navigate, useLocation } from "react-router-dom";
import { getJwt, ValidateJwt } from "../Helper/jwtHelper";

const GuardedRoute = ({ children }) => {
  let location = useLocation();
  let isLoggedIn = () => {
      let token = getJwt();
      return ValidateJwt(token);
  }

  return isLoggedIn().isValid ? (
    children
  ) : (
    <Navigate to="/SignIn" replace={true} state={{ from: location }} />
  );
};

export default GuardedRoute;
