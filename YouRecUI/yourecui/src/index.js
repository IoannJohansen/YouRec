import React from 'react';
import ReactDOM from 'react-dom';
import App from './Components/App/App.jsx';
import { connect, Provider } from 'react-redux';
import { bindActionCreators } from 'redux';
import { changeLoginStatus, changeAdminStatus } from './Store/Actions/UserActions/UserActions';
import { store} from './Store/Store';

const putStateToProps = (state) => {
  return {
    isLoggedIn: state.isLoggedIn,
    isAdmin: state.isAdmin,
    userName: state.userName,
    theme: state.theme,
    userRole: state.userRole
  }
};

const putActionsToProps = (dispatch) => {
  return {
    changeLoginStatus: bindActionCreators(changeLoginStatus, dispatch),
    changeAdminStatus: bindActionCreators(changeAdminStatus, dispatch)
  }
};

const WrapperAppComponent = connect(putStateToProps, putActionsToProps)(App);

ReactDOM.render(
  <Provider store={store} >
    <WrapperAppComponent />
  </Provider>,
  document.getElementById('root')
);