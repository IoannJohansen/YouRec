import { Component, React } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import Router from '../../Router/Router.jsx';
import { BrowserRouter } from 'react-router-dom';
import { ClearJwt, ValidateJwt } from '../../Helper/jwtHelper.js';

class App extends Component {
  componentDidMount() {
    const { login } = this.props;
    if (localStorage.getItem("jwt") != null) {
      const token = localStorage.getItem("jwt");
      let validationResult = ValidateJwt(token);
      if (validationResult.isValid) {
        login({ isAdmin: validationResult.isAdmin, userName: validationResult.userName, userId: validationResult.userId });
      } else {
        ClearJwt();
      }
    }
  }

  render() {
    return (
      <div>
        <BrowserRouter>
          <Router />
        </BrowserRouter>
      </div>
    );
  }
}

export default App;