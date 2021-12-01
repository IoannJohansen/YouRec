import axios from 'axios'
import {
    ADD_LIKE,
    ADD_RATING,
    API_URL,
    GET_RECOMMEND_USER_RATING
} from './ApiParameteres'
import {
    GetJwtAuthHeader
} from '../Helper/jwtHelper'

export const GetRecommendUserRating = async (userId, recommendId) => {
    const response = await axios.get(API_URL + GET_RECOMMEND_USER_RATING, {
        headers: GetJwtAuthHeader(),
        params: {
            userId: userId,
            recommendId: recommendId
        }
    })
    return response;
}

export const AddLike = async (userId, recommendId) => {
    const response = await axios.post(API_URL + ADD_LIKE, {
        userId: userId,
        recommendId: recommendId
    }, {
        headers: GetJwtAuthHeader()
    })
    return response;
}

export const AddRating = async (userId, recommendId, ratingValue) => {
    const response = axios.post(API_URL + ADD_RATING, {
        userId: userId,
        recommendId: recommendId,
        rate: ratingValue
    }, {
        headers: GetJwtAuthHeader()
    })
    return response;
}