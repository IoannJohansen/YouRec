import axios from 'axios';
import {
    GetJwtAuthHeader
} from '../Helper/jwtHelper';
import {
    API_URL,
    GET_USERS
} from './ApiParameteres';

export const getUsers = async (pageNum, pageSize) => {
    const response = await axios.get(API_URL + GET_USERS, {
        headers: GetJwtAuthHeader(),
        params: {
            PageNum: pageNum,
            pageSize: pageSize
        }
    })
    return response;
}