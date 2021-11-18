import { Component, React, createContext } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import Router from '../../Router/Router.jsx';
import { BrowserRouter } from 'react-router-dom';
import jwt from 'jsonwebtoken';

export const UserContext = createContext({
  isLoggedIn: false,
  userName: "Hell",
  isAdmin: false
});

class App extends Component {

  constructor() {
    super();
    this.state = {
      isLoggedIn: false,
      userName: "User",
      isAdmin: false
    }
  }

  componentDidMount() {
    if (localStorage.getItem("jwt") != null) {
      const token = localStorage.getItem("jwt");
      let decodedToken = jwt.decode(token, { complete: true });
      var dateNow = new Date();
      if (decodedToken.payload.exp * 1000 > dateNow.getTime()) {
        this.setState({ isLoggedIn: true });
      } else {
        localStorage.removeItem("jwt");
      }
    }
  }

  setAdmin = (newState) => this.setState({ isAdmin: newState })

  setLoginState = (newState) => this.setState({ isLoggedIn: newState })

  setUserNameState = (newState) => this.setState({ userName: newState })

  setInitState = (isLoggedIn, isAdmin, userName) => this.setState({ isLoggedIn: isLoggedIn, isAdmin: isAdmin, userName: userName })

  createContextValue = () => ({
    isLoggedIn: this.state.isLoggedIn,
    isAdmin: this.state.isAdmin,
    userName: this.state.userName,
    setAdmin: this.setAdmin,
    setLoginState: this.setLoginState,
    setUserNameState: this.setUserNameState,
    setInitState: this.setInitState
  })

  render() {

    return (
      <div>
        <UserContext.Provider value={this.createContextValue()}>
          <BrowserRouter>
            <Router />
          </BrowserRouter>
        </UserContext.Provider>
      </div>
    );
  }
}

export default App;