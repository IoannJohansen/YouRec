import { React, useState, useContext } from 'react';
import { Form, Button, ButtonGroup } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFacebook, faGoogle } from '@fortawesome/free-brands-svg-icons';
import axios from 'axios';
import Parameteres from '../../Api/ApiParameteres';
import { Link, useNavigate } from "react-router-dom";
import { UserContext } from '../App/App';
import { useForm } from 'react-hook-form';
import { EmailValidationOptions, PasswordValidationOptions } from '../../Helper/Validator';

export default function LoginForm() {

    const navigate = useNavigate();
    const [Email, SetEmail] = useState("");
    const [Password, SetPassword] = useState("");
    const userContext = useContext(UserContext);

    const {
        register,
        handleSubmit,
        formState: { errors } } = useForm();


    let onSubmitHandle = () => {
        let data = {
            "Email": Email,
            "Password": Password
        }

        axios.post(Parameteres.API_URL + Parameteres.SIGN_IN_PATH, JSON.stringify(data), { headers: { 'Content-Type': 'application/json' } }).then(response => {
            if (response.status === 200 && response.data.success) {
                userContext.setInitState(true, response.data.isAdmin, response.data.username)
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
            <p className="h2 text-center m-4">Login</p>
            <Form noValidate>
                {errors?.Email && <p className="text-danger">{errors?.Email?.message}</p>}
                {errors?.Password && <p className="text-danger">{errors?.Password?.message}</p>}
                <Form.Group controlId="formBasicEmail" className="mb-4">
                    <Form.Label>Email</Form.Label>
                    <Form.Control maxLength={40} {...register("Email", EmailValidationOptions)} value={Email} onChange={event => SetEmail(event.target.value)} placeholder="irecommend@mail.com" type="email" />
                </Form.Group>

                <Form.Group controlId="formBasicPassword">
                    <Form.Label>Password</Form.Label>
                    <Form.Control maxLength={40} {...register("Password", PasswordValidationOptions)} value={Password} onChange={event => SetPassword(event.target.value)} placeholder="Password" type="password" />
                </Form.Group>

                <div className="d-flex justify-content-between">
                    <Button className="mt-4" onClick={handleSubmit(onSubmitHandle)} type="submit" variant="primary">Submit</Button>
                    <Link to="/Register" className="mt-4 btn btn-success" type="submit" variant="success">Register</Link>
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