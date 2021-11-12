import { React } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import Header from '../Header/Header.jsx';
import Router from '../../Router/Router.jsx';


export default function App() {
  return (
    <div className="fluid">
      <Header />
      <Router />
    </div>
  );
}