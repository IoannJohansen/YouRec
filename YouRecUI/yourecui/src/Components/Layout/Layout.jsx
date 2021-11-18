import React from 'react'
import { Navbar } from 'react-bootstrap';

import NavHeader from './Navbar/Navbar';
import SearchPanel from './SearchPanel/SearchPanel.jsx';
import ControlGroup from './ControlGroup/ControlGroup.jsx';
import { Outlet } from 'react-router-dom';
import { UserContext } from '../App/App';

export default function Layout() {
    return (
        <UserContext.Consumer>
            {({ isLoggedIn, isAdmin, userName }) =>
                <div>
                    <Navbar expand="lg" bg="dark" variant="dark">
                        <Navbar.Brand className="h1 text-center">URec</Navbar.Brand>
                        <Navbar.Toggle />
                        <Navbar.Collapse className="justify-content-around" >
                            <NavHeader />
                            <SearchPanel />
                            <ControlGroup isAdmin={isAdmin} isLoggedIn={isLoggedIn} />
                        </Navbar.Collapse>
                    </Navbar>
                    <main>
                        <Outlet />
                    </main>
                </div>
            }
        </UserContext.Consumer>
    )
}