import { API_URL, SIGN_IN_FACEBOOK, SIGN_IN_GOOGLE } from '../Api/ApiParameteres';
import React from 'react'
import axios from 'axios';
import { GoogleLogin } from 'react-google-login';

export function HandleSuccessLogin(authResponse, navigate, userContext, setStatus) {
    if (authResponse.status === 200 && authResponse.data.success) {
        userContext.setInitState(true, authResponse.data.isAdmin, authResponse.data.username)
        localStorage.setItem("jwt", authResponse.data.token);
        navigate('/Recs');
    } else {
        setStatus("Invalid login or password");
    }
}

export function SignInGoogle(props) {
    return (
        <GoogleLogin
            clientId={'467666703976-2v1pdp4p8v5rtho06lo6b5uvmv09jnfd.apps.googleusercontent.com'}
            buttonText="Login"
            onSuccess={successLogginGoogle}
            onFailure={failLogginGoogle}
            autoLoad={false}
        />
    );
}

function successLogginGoogle(response) {
    console.log(response);
    axios.post(API_URL + SIGN_IN_GOOGLE, {
        Id_token: response.tokenId,
        Email: response.Au.pv
    }).then(res => {
        console.log(res);
    })
}

function failLogginGoogle(response) {
    console.log(response);

}