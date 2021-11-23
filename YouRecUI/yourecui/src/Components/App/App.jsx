import { Component, React } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import Router from '../../Router/Router.jsx';
import { BrowserRouter } from 'react-router-dom';
import jwt from 'jsonwebtoken';

class App extends Component {

  componentDidMount() {
    const { login } = this.props;
    if (localStorage.getItem("jwt") != null) {

      const token = localStorage.getItem("jwt");
      let decodedToken = jwt.decode(token, { complete: true });
      var dateNow = new Date();
      if (decodedToken.payload.exp * 1000 > dateNow.getTime()) {
        login({ isAdmin: decodedToken.payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] === "Admin", userName: decodedToken.payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"] })
      } else {
        localStorage.removeItem("jwt");
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