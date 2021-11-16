import { React, useState } from 'react';
import { Form, Button, ButtonGroup } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFacebook, faGoogle } from '@fortawesome/free-brands-svg-icons';
import axios from 'axios';
import Parameteres from '../../Api/ApiParameteres';
import { useNavigate } from "react-router-dom";

export default function LoginForm(props) {

    const navigate = useNavigate();

    let onSubmitHandle = (e) => {
        e.preventDefault();
        let data = {
            "Email": Email,
            "Password": Password
        }

        axios.post(Parameteres.API_URL + Parameteres.SIGN_IN_PATH, JSON.stringify(data), { headers: { 'Content-Type': 'application/json' } }).then(response => {
            console.log(response);
            if (response.status === 200 && response.data.success) {
                navigate('/Recs');
            } else {

            }
        }).catch(error => {
            console.log(`Error: ${error}`);
        });
    }

    alert(props.location.state.name)

    const [Email, SetEmail] = useState("");
    const [Password, SetPassword] = useState("");

    return (
        <div className="container col-sm-4">
            <p className="h2 text-center m-4">Login</p>
            <Form>
                <Form.Group controlId="formBasicEmail" className="mb-4">
                    <Form.Label>Email</Form.Label>
                    <Form.Control value={Email} onChange={event => SetEmail(event.target.value)} placeholder="irecommend@mail.com" type="email" />
                </Form.Group>

                <Form.Group controlId="formBasicPassword">
                    <Form.Label>Password</Form.Label>
                    <Form.Control value={Password} onChange={event => SetPassword(event.target.value)} placeholder="Password" type="password" />
                </Form.Group>

                <div className="d-flex justify-content-between">
                    <Button className="mt-4" onClick={onSubmitHandle} type="submit" variant="primary">Submit</Button>
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