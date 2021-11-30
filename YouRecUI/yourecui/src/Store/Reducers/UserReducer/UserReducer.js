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
            return {
                ...state,
                isLoggedIn: true,
                isAdmin: action.payload.isAdmin,
                userName: action.payload.userName,
                userId: action.payload.userId,
            }
        }

        case USER_ACTION_LOGOUT: {
            return {
                ...state,
                isLoggedIn: false,
                isAdmin: false,
                userName: '',
                userId: '',
            }
        }

        default:
            return state;
    }
}