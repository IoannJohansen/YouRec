import { ACTION_CHANGE_LOGIN_STATUS, ACTION_CHANGE_ADMIN_STATUS } from '../../ActionTypes/UserActionTypes';
import { initState } from '../UserReducer/InitialState'

export const userReducer = (state = initState, action) => {
    switch (action.type) {
        case ACTION_CHANGE_LOGIN_STATUS:
            return { ...state, isLoggedIn: action.payload }

        case ACTION_CHANGE_ADMIN_STATUS:
            return { ...state, isAdmin: action.payload }

        default:
            break;
    }
    return state;
}