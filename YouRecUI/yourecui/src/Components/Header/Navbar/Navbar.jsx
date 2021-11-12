import React from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import { Nav, NavLink } from 'react-bootstrap';
import { Link } from 'react-router-dom'

export default function NavBar() {
    return (
        <Nav>
            <Nav.Link>
                <Link className="nav-link" to="/Recs">Recommends</Link>
            </Nav.Link>
            <Nav.Link>
                <Link className="nav-link" to="/MyRecs">My Recommends</Link>
            </Nav.Link>
            <Nav.Link href="#3">
                <Link className="nav-link" to="/CreateRec">Create recommend</Link>
            </Nav.Link>
        </Nav>
    );
}