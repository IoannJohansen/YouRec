import React from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import { Nav } from 'react-bootstrap';
import { Link } from 'react-router-dom'

export default function NavBar() {
    return (
        <Nav>
            <Link className="nav-link" to="/Recs">Recommends</Link>
            <Link className="nav-link" to="/MyRecs">My Recommends</Link>
            <Link className="nav-link" to="/CreateRec">Create recommend</Link>
        </Nav>
    );
}