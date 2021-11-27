import { API_URL, SIGN_IN_GOOGLE, MICROSOFT_SIGN_IN, GOOGLE_CLIENT_ID, MICROSOFT_CLIENT_ID } from './ApiParameteres';
import { React } from 'react'
import axios from 'axios';
import { MicrosoftLogin } from "react-microsoft-login";
import { GoogleLoginButton, MicrosoftLoginButton } from "react-social-login-buttons";
import { GoogleLogin } from 'react-google-login';
import { login } from '../Store/Actions/UserActions/UserActions';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { SetJwt } from '../Helper/jwtHelper';

export function HandleSuccessLogin(authResponse, navigate, setStatus, dispatch) {
    if (authResponse.status === 200 && authResponse.data.success) {
        console.log(authResponse);
        dispatch(login({ isAdmin: authResponse.data.isAdmin, userName: authResponse.data.username }));
        SetJwt(authResponse.data.token);
        navigate('/Recs');
    } else {
        setStatus("Invalid login or password");
    }
}

export function SignInGoogleButton(props) {
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const successAuthHandler = (res) => {
        axios.post(API_URL + SIGN_IN_GOOGLE, {
            Id_token: res.tokenId,
            Provider: "google"
        }).then(res => {
            console.log(res);
            HandlAuthResponse(res);
        })
    }

    const HandlAuthResponse = (res) => {
        if (res.status === 200) {
            dispatch(login({ isAdmin: false, userName: res.data.username }))
            SetJwt(res.data.token);
            navigate("/Recs");
        } else {
            console.log("Error");
        }
    }

    return (
        <GoogleLogin
            theme="light"
            clientId={GOOGLE_CLIENT_ID}
            onSuccess={successAuthHandler}
            onFailure={props.onfail}
            cookiePolicy={'single_host_origin'}
            render={GoogleLoginButton}
        />
    );
}

export function SignInMicrosoftButton(props) {
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const authHandler = (err, data) => {
        if (data == null) {
            props.onfail();
            return;
        }
        axios.post(API_URL + MICROSOFT_SIGN_IN, {
            Id_token: data.idToken.rawIdToken,
            Provider: "microsoft"
        }).then(res => {
            if (res.status === 200) {
                dispatch(login({ isAdmin: false, userName: res.data.username }))
                SetJwt(res.data.token);
                navigate("/Recs");
            } else {
                console.log("Error");
                props.onfail();
            }
        })
        sessionStorage.clear();
    }

    return (
        <MicrosoftLogin
            clientId={MICROSOFT_CLIENT_ID}
            authCallback={authHandler}
            children={<MicrosoftLoginButton />}
        />
    );
}