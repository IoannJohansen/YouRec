import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { FormControl, Nav, Form, Button } from 'react-bootstrap';

export default function SearchPanel() {
    return (
        <Nav>
            <Form className="d-flex justify-content-around">
                <FormControl
                    type="search"
                    placeholder="Type your query" 
                    className="m-1"
                    aria-label="Search"
                />
                <Button variant="success" className="btn-sm m-1">Search</Button>
            </Form>
        </Nav>
    );
}
