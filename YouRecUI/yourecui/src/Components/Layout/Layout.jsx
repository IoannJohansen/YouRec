import React from 'react'
import { Navbar } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCommentAlt } from '@fortawesome/free-solid-svg-icons';
import NavHeader from './Navbar/Navbar';
import SearchPanel from './SearchPanel/SearchPanel.jsx';
import ControlGroup from './ControlGroup/ControlGroup.jsx';
import { Outlet } from 'react-router-dom';
import { UserContext } from '../App/App';
import { Link } from 'react-router-dom';

export default function Layout() {
    return (
        <UserContext.Consumer>
            {({ isLoggedIn, isAdmin, userName }) =>
                <div>
                    <Navbar expand="lg" bg="dark" variant="dark">
                        <Navbar.Brand className="text-center h1">UREC</Navbar.Brand>
                        <Navbar.Toggle />
                        <Navbar.Collapse className="justify-content-around" >
                            <SearchPanel />
                            <NavHeader />
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