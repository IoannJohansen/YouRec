import { React, useState } from 'react';
import { Form, Button } from 'react-bootstrap'
import axios from 'axios';
import Parameteres from '../../Api/ApiParameteres';
import { Link, useNavigate } from "react-router-dom";
import { useForm } from 'react-hook-form';
import { EmailValidationOptions, PasswordValidationOptions, FirstNameValidationOptions, LastNameValidationOptions } from '../../Helper/Validator';
import { HandleSuccessLogin, SignInGoogleButton, SignInMicrosoftButton } from '../../Api/Auth';
import { useDispatch } from 'react-redux';

export default function RegisterForm() {
    const navigate = useNavigate();
    const [Email, SetEmail] = useState("");
    const [Password, SetPassword] = useState("");
    const [FirstName, SetFirstName] = useState("");
    const [Lastname, SetLastName] = useState("");
    const [status, setStatus] = useState(null);

    const {
        register,
        handleSubmit,
        formState: { errors } } = useForm();
    const dispatch = useDispatch();

    let onSubmitHandle = (e) => {
        let data = {
            "Email": Email,
            "Password": Password,
            "FirstName": FirstName,
            "LastName": Lastname
        }

        axios.post(Parameteres.API_URL + Parameteres.SIGN_UP_PATH, JSON.stringify(data), { headers: { 'Content-Type': 'application/json' } }).then(response => {
            HandleSuccessLogin(response, navigate, setStatus, dispatch);
        }).catch(error => {
            setStatus("Invalid login or password");
        });
    }

    return (
        <div className="container col-sm-4">
            <p className="h2 text-center m-4">Register</p>
            {status &&
                <div className={'alert alert-danger'}>{status}</div>
            }
            <Form>
                <Form.Group className="mb-2">
                    <Form.Label>Email</Form.Label>
                    {errors?.Email && <p className="text-danger">{errors?.Email?.message}</p>}
                    <Form.Control {...register("Email", EmailValidationOptions)} maxLength={40} value={Email} onChange={event => SetEmail(event.target.value)} placeholder="irecommend@mail.com" type="email" />
                </Form.Group>

                <Form.Group className="mb-2">
                    <Form.Label>First name</Form.Label>
                    {errors?.FirstName && <p className="text-danger">{errors?.FirstName?.message}</p>}
                    <Form.Control {...register("FirstName", FirstNameValidationOptions)} maxLength={25} value={FirstName} onChange={event => SetFirstName(event.target.value)} placeholder="First name" type="text" />
                </Form.Group>

                <Form.Group className="mb-2">
                    <Form.Label>Last name</Form.Label>
                    {errors?.LastName && <p className="text-danger">{errors?.LastName?.message}</p>}
                    <Form.Control {...register("LastName", LastNameValidationOptions)} maxLength={25} value={Lastname} onChange={event => SetLastName(event.target.value)} placeholder="Last name" type="text" />
                </Form.Group>

                <Form.Group className="mb-2">
                    <Form.Label>Password</Form.Label>
                    {errors?.Password && <p className="text-danger">{errors?.Password?.message}</p>}
                    <Form.Control {...register("Password", PasswordValidationOptions)} maxLength={40} value={Password} onChange={event => SetPassword(event.target.value)} placeholder="Password" type="password" />
                </Form.Group>

                <div className="d-flex justify-content-between">
                    <Button className="mt-4" onClick={handleSubmit(onSubmitHandle)} type="submit" variant="primary">Submit</Button>
                    <Link to="/SignIn" className="mt-4 btn btn-success" type="submit" variant="primary">Login</Link>
                </div>

                <div className="d-flex flex-column text-center  mt-3">
                    <SignInGoogleButton onfail={() => setStatus("Google authentication failure")} />
                    <SignInMicrosoftButton onfail={() => setStatus("Microsoft authentication failure")} />
                </div>
            </Form>
        </div>
    )
}