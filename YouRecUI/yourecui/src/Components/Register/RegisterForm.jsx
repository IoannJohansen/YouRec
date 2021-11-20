import { React, useContext, useState } from 'react';
import { Form, Button, ButtonGroup } from 'react-bootstrap'
import axios from 'axios';
import Parameteres from '../../Api/ApiParameteres';
import { Link, useNavigate } from "react-router-dom";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFacebook, faGoogle } from '@fortawesome/free-brands-svg-icons';
import { UserContext } from '../App/App';


export default function RegisterForm() {
    const navigate = useNavigate();
    const [Email, SetEmail] = useState("");
    const [Password, SetPassword] = useState("");
    const [FirstName, SetFirstName] = useState("");
    const [Lastname, SetLastName] = useState("");
    const userContext = useContext(UserContext);

    let onSubmitHandle = (e) => {
        e.preventDefault();

        let data = {
            "Email": Email,
            "Password": Password,
            "FirstName": FirstName,
            "LastName": Lastname
        }

        axios.post(Parameteres.API_URL + Parameteres.SIGN_UP_PATH, JSON.stringify(data), { headers: { 'Content-Type': 'application/json' } }).then(response => {
            if (response.status === 200 && response.data.success) {
                userContext.setInitState(true, true, response.data.username)
                localStorage.setItem("jwt", response.data.token);
                navigate('/Recs');
            } else {
                alert("Bad login");
            }
        }).catch(error => {
            console.log(`Error: ${error}`);
        });
    }

    return (
        <div className="container col-sm-4">
            <p className="h2 text-center m-4">Register</p>
            <Form>
                <Form.Group className="mb-2">
                    <Form.Label>Email</Form.Label>
                    <Form.Control value={Email} onChange={event => SetEmail(event.target.value)} placeholder="irecommend@mail.com" type="email" />
                </Form.Group>

                <Form.Group className="mb-2">
                    <Form.Label>First name</Form.Label>
                    <Form.Control value={FirstName} onChange={event => SetFirstName(event.target.value)} placeholder="First name" type="text" />
                </Form.Group>

                <Form.Group className="mb-2">
                    <Form.Label>Last name</Form.Label>
                    <Form.Control value={Lastname} onChange={event => SetLastName(event.target.value)} placeholder="Last name" type="text" />
                </Form.Group>

                <Form.Group className="mb-2">
                    <Form.Label>Password</Form.Label>
                    <Form.Control value={Password} onChange={event => SetPassword(event.target.value)} placeholder="Password" type="password" />
                </Form.Group>

                <div className="d-flex justify-content-between">
                    <Button className="mt-4" onClick={onSubmitHandle} type="submit" variant="primary">Submit</Button>
                    <Link to="/SignIn" className="mt-4 btn btn-success" type="submit" variant="primary">Login</Link>
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
    )
}