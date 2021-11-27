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