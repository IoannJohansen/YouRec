import React from 'react'
import { Navbar } from 'react-bootstrap';

import NavHeader from './Navbar/Navbar';
import SearchPanel from './SearchPanel/SearchPanel.jsx';
import ControlGroup from './ControlGroup/ControlGroup.jsx';

export default function Header() {
    return (
        <Navbar expand="lg" bg="dark" variant="dark">
            <Navbar.Brand>YouRec</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse className="justify-content-around" id="basic-navbar-nav">
                <NavHeader />
                <SearchPanel />
                <ControlGroup isAdmin={true} isLoggedIn={true} />
            </Navbar.Collapse>
        </Navbar>
    )
}