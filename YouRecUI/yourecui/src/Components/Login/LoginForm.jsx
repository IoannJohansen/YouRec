import { React, useState, useContext } from 'react';
import { Form, Button, ButtonGroup } from 'react-bootstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFacebook, faGit, faGithub, faGitlab, faGoogle, faTwitter } from '@fortawesome/free-brands-svg-icons';
import axios from 'axios';
import Parameteres from '../../Api/ApiParameteres';
import { Link, useNavigate } from "react-router-dom";
import { UserContext } from '../App/App';
import { useForm } from 'react-hook-form';
import { EmailValidationOptions, PasswordValidationOptions } from '../../Helper/Validator';
import { SignInGoogle, HandleSuccessLogin } from '../../Api/Auth';

export default function LoginForm() {

    const navigate = useNavigate();
    const [Email, SetEmail] = useState("");
    const [Password, SetPassword] = useState("");
    const userContext = useContext(UserContext);
    const [status, setStatus] = useState(null);

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
            HandleSuccessLogin(response, navigate, userContext, setStatus);
        }).catch(error => {
            setStatus("Invalid login or password");
        });
    }

    return (
        <div className="container col-sm-4">
            <p className="h2 text-center m-4">Login</p>
            {status &&
                <div className={'alert alert-danger'}>{status}</div>
            }
            <Form noValidate>
                <Form.Group controlId="formBasicEmail" className="mb-4">
                    <Form.Label>Email</Form.Label>
                    {errors?.Email && <p className="text-danger">{errors?.Email?.message}</p>}
                    <Form.Control maxLength={40} {...register("Email", EmailValidationOptions)} value={Email} onChange={event => SetEmail(event.target.value)} placeholder="irecommend@mail.com" type="email" />
                </Form.Group>

                <Form.Group controlId="formBasicPassword">
                    <Form.Label>Password</Form.Label>
                    {errors?.Password && <p className="text-danger">{errors?.Password?.message}</p>}
                    <Form.Control maxLength={40} {...register("Password", PasswordValidationOptions)} value={Password} onChange={event => SetPassword(event.target.value)} placeholder="Password" type="password" />
                </Form.Group>

                <div className="d-flex justify-content-between">
                    <Button className="mt-4" onClick={handleSubmit(onSubmitHandle)} type="submit" variant="primary">Submit</Button>
                    <Link to="/Register" className="mt-4 btn btn-success" type="submit" variant="success">Register</Link>
                </div>

                <p className="h2 text-center mt-5">Or use external networks:</p>
                <div className="d-flex justify-content-around">

                    <ButtonGroup>
                        <SignInGoogle />
                        {/* <Button className="btn-lg"><FontAwesomeIcon icon={faGoogle} /></Button> */}
                        <Button className="btn-lg"><FontAwesomeIcon icon={faGithub} /></Button>
                    </ButtonGroup>

                </div>

            </Form>
        </div>
    );
}