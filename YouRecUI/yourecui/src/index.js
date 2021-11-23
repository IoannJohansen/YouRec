import React from 'react';
import ReactDOM from 'react-dom';
import App from './Components/App/App.jsx';
import {
  connect,
  Provider
} from 'react-redux';
import {
  login,
  logout
} from './Store/Actions/UserActions/UserActions';
import {
  store
} from './Store/Store';

const mapStateToProps = (state) => {
  return {
    isLoggedIn: state.isLoggedIn,
    isAdmin: state.isAdmin,
    userName: state.userName
  }
};

const mapActionsToProps = {
  login,
  logout
};

const WrapperAppComponent = connect(mapStateToProps, mapActionsToProps)(App);

ReactDOM.render(
  <Provider store={store} >
    <WrapperAppComponent />
  </Provider>,
  document.getElementById('root')
);