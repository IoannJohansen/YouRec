import { React, useState } from "react";
import { Form, Button } from "react-bootstrap";
import axios from "axios";
import Parameteres from "../../Api/ApiParameteres";
import { Link, useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form";
import {
  EmailValidationOptions,
  PasswordValidationOptions,
} from "../../Helper/Validator";
import {
  SignInGoogleButton,
  HandleSuccessLogin,
  SignInMicrosoftButton,
} from "../../Api/ApiAuth";
import { useDispatch } from "react-redux";

export default function LoginForm() {
  const navigate = useNavigate();
  const [Email, SetEmail] = useState("");
  const [Password, SetPassword] = useState("");
  const [status, setStatus] = useState(null);
  const dispatch = useDispatch();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  let onSubmitHandle = () => {
    let data = {
      Email: Email,
      Password: Password,
    };

    axios
      .post(
        Parameteres.API_URL + Parameteres.SIGN_IN_PATH,
        JSON.stringify(data),
        { headers: { "Content-Type": "application/json" } }
      )
      .then((response) => {
        HandleSuccessLogin(response, navigate, setStatus, dispatch);
      })
      .catch((error) => {
        console.log("ERROR " + error);
        setStatus("Invalid login or password");
      });
  };

  return (
    <div className="container col-sm-4">
      <p className="h2 text-center m-4">Login</p>
      {status && <div className={"alert alert-danger"}>{status}</div>}
      <Form noValidate>
        <Form.Group controlId="formBasicEmail" className="mb-4">
          <Form.Label>Email</Form.Label>
          {errors?.Email && (
            <p className="text-danger">{errors?.Email?.message}</p>
          )}
          <Form.Control
            maxLength={40}
            {...register("Email", EmailValidationOptions)}
            value={Email}
            onChange={(event) => SetEmail(event.target.value)}
            placeholder="irecommend@mail.com"
            type="email"
          />
        </Form.Group>

        <Form.Group controlId="formBasicPassword">
          <Form.Label>Password</Form.Label>
          {errors?.Password && (
            <p className="text-danger">{errors?.Password?.message}</p>
          )}
          <Form.Control
            maxLength={40}
            {...register("Password", PasswordValidationOptions)}
            value={Password}
            onChange={(event) => SetPassword(event.target.value)}
            placeholder="Password"
            type="password"
          />
        </Form.Group>

        <div className="d-flex justify-content-between">
          <Button
            className="mt-4"
            onClick={handleSubmit(onSubmitHandle)}
            type="submit"
            variant="primary"
          >
            Submit
          </Button>
          <Link
            to="/Register"
            className="mt-4 btn btn-success"
            type="submit"
            variant="success"
          >
            Register
          </Link>
        </div>

        <div className="d-flex flex-column text-center mt-3">
          <SignInGoogleButton
            onfail={() => setStatus("Google authentication failure")}
          />
          <SignInMicrosoftButton
            onfail={() => setStatus("Microsoft authentication failure")}
          />
        </div>
      </Form>
    </div>
  );
}
