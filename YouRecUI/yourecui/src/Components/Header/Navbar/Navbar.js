import React from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import { Nav } from 'react-bootstrap';

export default function NavBar() {
    return (
        <Nav>
            <Nav.Link href="#1">
                Feedbacks
            </Nav.Link>
            <Nav.Link href="#2">
                My feedbacks
            </Nav.Link>
            <Nav.Link href="#3">
                Create feedback
            </Nav.Link>
        </Nav>
    );
}