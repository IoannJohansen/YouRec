import React from 'react'
import { Navbar } from 'react-bootstrap';

import NavHeader from './Navbar/Navbar';
import SearchPanel from './SearchPanel/SearchPanel.jsx';
import ControlGroup from './ControlGroup/ControlGroup.jsx';
import { Outlet } from 'react-router-dom';

export default function Layout() {
    return (
        <>
            <Navbar expand="lg" bg="dark" variant="dark">
                <Navbar.Brand className="h1 text-center">URec</Navbar.Brand>
                <Navbar.Toggle />
                <Navbar.Collapse className="justify-content-around" >
                    <NavHeader />
                    <SearchPanel />
                    <ControlGroup isAdmin={true} isLoggedIn={true} />
                </Navbar.Collapse>
            </Navbar>
            <main>
                <Outlet />
            </main>
        </>
    )
}