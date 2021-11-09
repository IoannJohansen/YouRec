import { React } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import { Navbar } from 'react-bootstrap';

import NavHeader from '../Header/Navbar/Navbar';
import SearchPanel from '../Header/SearchPanel/SearchPanel';
import ControlGroup from '../Header/ControlGroup/ControlGroup';

export default function App() {
  return (
    <Navbar expand="lg" bg="dark" variant="dark">
      <Navbar.Brand>YouRec</Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse className="justify-content-around" id="basic-navbar-nav">
        <NavHeader />
        <SearchPanel />
        <ControlGroup />
      </Navbar.Collapse>
    </Navbar>
  );
}