import { ACTION_CHANGE_LOGIN_STATUS, ACTION_CHANGE_ADMIN_STATUS } from '../../ActionTypes/UserActionTypes';

export const changeLoginStatus = (newLoginStatus) => {
    return {
        type: ACTION_CHANGE_LOGIN_STATUS,
        payload: newLoginStatus
    }
}

export const changeAdminStatus = (newAdminStatus) => {
    return {
        type: ACTION_CHANGE_ADMIN_STATUS,
        payload: newAdminStatus
    }
}