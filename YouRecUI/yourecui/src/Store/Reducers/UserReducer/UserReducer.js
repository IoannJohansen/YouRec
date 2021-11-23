import {
    USER_ACTION_LOGIN,
    USER_ACTION_LOGOUT
} from '../../ActionTypes/UserActionTypes';
import {
    initState
} from './InitialState'

export const userReducer = (state = initState, action) => {
    switch (action.type) {
        case USER_ACTION_LOGIN: {
            console.log(action);
            return {
                ...state,
                isLoggedIn: true,
                isAdmin: action.payload.isAdmin,
                userName: action.payload.userName
            }
        }

        case USER_ACTION_LOGOUT: {
            return {
                ...state,
                isLoggedIn: false,
                isAdmin: false,
                userName: ''
            }
        }

        default:
            return state;
    }
}