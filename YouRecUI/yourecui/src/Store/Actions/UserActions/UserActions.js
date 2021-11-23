import { USER_ACTION_LOGIN, USER_ACTION_LOGOUT } from '../../ActionTypes/UserActionTypes';

export const login = (authData) => {
    return {
        type: USER_ACTION_LOGIN,
        payload: authData
    }
}

export const logout = (authData) => {
    return {
        type: USER_ACTION_LOGOUT,
        payload: authData
    }
}