import axios from 'axios';
import {
    GetJwtAuthHeader
} from '../Helper/jwtHelper';
import {
    ADD_RECOMMEND_WITH_ID,
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

export const addRecommendWithId = async (formData) => {
    const response = await axios.post(API_URL + ADD_RECOMMEND_WITH_ID, formData, {
        headers: GetJwtAuthHeader()
    })
    return response;
}