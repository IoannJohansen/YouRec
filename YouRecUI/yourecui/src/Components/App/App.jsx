import { React } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import Router from '../../Router/Router.jsx';
import { BrowserRouter } from 'react-router-dom';

export default function App() {
  return (
    <div>
      <BrowserRouter>
        <Router />
      </BrowserRouter>
    </div>
  );
}