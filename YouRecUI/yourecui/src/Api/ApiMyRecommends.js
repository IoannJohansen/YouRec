import axios from 'axios'
import {
    getJwt,
    GetJwtAuthHeader
} from '../Helper/jwtHelper'
import {
    API_URL,
    DELETE_RECOMMEND,
    GET_FOR_USER,
    GET_SORTED
} from './ApiParameteres'

export const getRecommendsSorted = async (userId, order, sortMode, pageNum, amount) => {
    const response = await axios.get(API_URL + GET_SORTED, {
        params: {
            UserId: userId,
            SortMode: sortMode,
            SortOrder: order,
            PageNumber: pageNum,
            Amount: amount
        },
        headers: GetJwtAuthHeader()
    })
    return response;
}

export const getRecommendsForUser = async (userId, pageNum, amount) => {
    const res = await axios.get(API_URL + GET_FOR_USER, {
        params: {
            UserId: userId,
            PageNumber: pageNum,
            Amount: amount
        },
        headers: GetJwtAuthHeader()
    })
    return res;
}

export const deleteRecommend = async (id) => {
    const response = await axios.delete(API_URL + DELETE_RECOMMEND, {
        headers: GetJwtAuthHeader(),
        params: {
            recommendId: id
        }
    })
    return response;
}