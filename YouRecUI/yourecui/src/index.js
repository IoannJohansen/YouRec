import React from "react";
import ReactDOM from "react-dom";
import App from "./Components/App/App.jsx";
import { connect, Provider } from "react-redux";
import { login, logout } from "./Store/ActionCreators/UserActions/UserActions";
import { store } from "./Store/Store";
import { BrowserRouter } from "react-router-dom";

const mapStateToProps = (state) => {
  return {
    isLoggedIn: state.isLoggedIn,
    isAdmin: state.isAdmin,
    userName: state.userName,
    userId: state.userId,
  };
};

const mapActionsToProps = {
  login,
  logout,
};

const WrapperAppComponent = connect(mapStateToProps, mapActionsToProps)(App);

ReactDOM.render(
  <Provider store={store}>
    <WrapperAppComponent />
  </Provider>,
  document.getElementById("root")
);
