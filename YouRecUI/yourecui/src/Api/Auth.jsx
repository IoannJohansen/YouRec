import { API_URL, SIGN_IN_GOOGLE, MICROSOFT_SIGN_IN } from './ApiParameteres';
import { React } from 'react'
import axios from 'axios';
import { MicrosoftLogin } from "react-microsoft-login";
import { GoogleLoginButton, MicrosoftLoginButton } from "react-social-login-buttons";
import { GoogleLogin } from 'react-google-login';
import { login } from '../Store/Actions/UserActions/UserActions';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';

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
        console.log(res);
        if (res.status === 200) {
            dispatch(login({ isAdmin: false, userName: res.data.username }))
            localStorage.setItem("jwt", res.data.token);
            navigate("/Recs");
        } else {
            console.log("Error");
        }
    }

    return (
        <GoogleLogin
            theme="light"
            clientId={'467666703976-2v1pdp4p8v5rtho06lo6b5uvmv09jnfd.apps.googleusercontent.com'}
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
        console.log(data);
        axios.post(API_URL + MICROSOFT_SIGN_IN, {
            Id_token: data.idToken.rawIdToken,
            Provider: "microsoft"
        }).then(res => {
            console.log(res);
            if (res.status === 200) {
                dispatch(login({ isAdmin: false, userName: res.data.username }))
                localStorage.setItem("jwt", res.data.token);
                navigate("/Recs");
            } else {
                console.log("Error");
            }
        })
        sessionStorage.clear();
    }

    return (
        <MicrosoftLogin
            clientId={"2a72ff00-fc7d-4aff-96ea-09f592f8dc1a"}
            authCallback={authHandler}
            children={<MicrosoftLoginButton />}
        />
    );
}