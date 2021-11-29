import jwt from 'jsonwebtoken';

const jwtTokenname = "jwt";

export function getJwt() {
    let token = localStorage.getItem(jwtTokenname);
    return token;
}

export function SetJwt(token) {
    localStorage.setItem(jwtTokenname, token);
}

export function ClearJwt() {
    localStorage.removeItem(jwtTokenname);
}

export function ValidateJwt(token) {
    let decodedToken = jwt.decode(token, {
        complete: true
    });
    var dateNow = new Date();
    if (decodedToken.payload.exp * 1000 > dateNow.getTime()) {
        return {
            isValid: true,
            isAdmin: decodedToken.payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] === "Admin",
            userName: decodedToken.payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]
        }
    } else {
        return {
            isValid: false
        }
    }
}

