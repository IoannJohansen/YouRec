import React from 'react';
import { Form, Button, ButtonGroup } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFacebook, faGoogle, faVk } from '@fortawesome/free-brands-svg-icons';

export default function LoginForm() {
    return (
        <div className="container col-sm-4">
            <p className="h2 text-center m-4">Login</p>
            <Form>
                <Form.Group controlId="formBasicEmail" className="mb-4">
                    <Form.Label>Email</Form.Label>
                    <Form.Control placeholder="irecommend@mail.com" type="email" />
                </Form.Group>
                
                <Form.Group controlId="formBasicPassword">
                    <Form.Label>Password</Form.Label>
                    <Form.Control placeholder="Password" type="password" />
                </Form.Group>

                <div className="d-flex justify-content-between">
                    <Button className="mt-4" type="submit" variant="primary">Submit</Button>
                    <Button className="mt-4" type="submit" variant="success">Register</Button>
                </div>  

                <p className="h2 text-center mt-5">Or use external networks:</p>
                <div className="d-flex justify-content-around">
                    <ButtonGroup>
                        <Button className="btn-lg"><FontAwesomeIcon icon={faFacebook} /></Button>
                        <Button className="btn-lg"><FontAwesomeIcon icon={faGoogle} /></Button>
                    </ButtonGroup>

                </div>

            </Form>
        </div>
    );
}