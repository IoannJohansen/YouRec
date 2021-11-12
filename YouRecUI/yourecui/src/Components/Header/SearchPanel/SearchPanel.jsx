import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { FormControl, Nav } from 'react-bootstrap';

export default function SearchPanel() {
    return (
        <Nav>
            <FormControl type="Search" aria-label="Search" placeholder="Search" />
        </Nav>
    );
}
