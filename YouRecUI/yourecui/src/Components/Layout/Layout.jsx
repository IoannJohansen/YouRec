import React from 'react'
import { Navbar } from 'react-bootstrap';
import NavHeader from './Navbar/Navbar';
import SearchPanel from './SearchPanel/SearchPanel.jsx';
import ControlGroup from './ControlGroup/ControlGroup.jsx';
import { Outlet } from 'react-router-dom';
import { useSelector } from 'react-redux';

export default function Layout() {
    const isAdmin = useSelector(state => state.isAdmin);
    const isLoggedIn = useSelector(state => state.isLoggedIn);

    return (
        <div>
            <Navbar className="col-md-12 col-sm-12 col-xs-12" expand="lg" bg="dark" variant="dark">
                <Navbar.Brand className="text-center h1">UREC</Navbar.Brand>
                <Navbar.Toggle />
                <Navbar.Collapse className="justify-content-around" >
                    {/* <SearchPanel /> */}
                    <NavHeader />
                    <ControlGroup isAdmin={isAdmin} isLoggedIn={isLoggedIn} />
                </Navbar.Collapse>
            </Navbar>
            <Outlet />
        </div>
    )
}