import { API_URL, SIGN_IN_GOOGLE, MICROSOFT_SIGN_IN } from './ApiParameteres';
import { React } from 'react'
import axios from 'axios';
import { MicrosoftLogin } from "react-microsoft-login";
import { GoogleLoginButton, MicrosoftLoginButton } from "react-social-login-buttons";
import { GoogleLogin } from 'react-google-login';
import { login } from '../Store/Actions/UserActions/UserActions';

export function HandleSuccessLogin(authResponse, navigate, setStatus, dispatch) {
    if (authResponse.status === 200 && authResponse.data.success) {
        console.log(authResponse);
        dispatch(login({ isAdmin: authResponse.data.isAdmin, userName: authResponse.data.username }));
        localStorage.setItem("jwt", authResponse.data.token);
        navigate('/Recs');
    } else {
        setStatus("Invalid login or password");
    }
}

//TODO: parms: login dto | simple login
// export function Login() {

// }

//TODO: reg reg dto | simple register
export function Register() {

}

//TODO: validate token
export function ValidateToken() {

}

export function SignInGoogleButton() {
    return (
        <GoogleLogin
            theme="light"
            clientId={'467666703976-2v1pdp4p8v5rtho06lo6b5uvmv09jnfd.apps.googleusercontent.com'}
            onSuccess={successLogginGoogle}
            cookiePolicy={'single_host_origin'}
            render={GoogleLoginButton}
        />
    );
}

export function SignInMicrosoftButton() {


    return (
        <MicrosoftLogin
            clientId={"b95edfca-7e7a-47e1-b184-908e978aec1d"}
            authCallback={authHandler}
            children={<MicrosoftLoginButton />}
        />
    );
}

export function HandleAuthResponse(AuthResult) {
    console.log(AuthResult);
    login({ isAdmin: false, userName: AuthResult.data.username });
    localStorage.setItem("jwt", AuthResult.data.token);
}

function authHandler(err, data) {
    axios.post(API_URL + MICROSOFT_SIGN_IN, {
        Id_token: data.idToken.rawIdToken,
        Provider: "microsoft"
    }).then(res => {
        HandleAuthResponse(res);
    })
    sessionStorage.clear();
}

function successLogginGoogle(response) {
    axios.post(API_URL + SIGN_IN_GOOGLE, {
        Id_token: response.tokenId,
        Provider: "google"
    }).then(res => {
        HandleAuthResponse(res);
    })
}

