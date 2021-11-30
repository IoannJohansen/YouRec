import axios from 'axios'
import {
    getJwt
} from '../Helper/jwtHelper';
import {
    API_URL,
    GET_COMMENTS,
    GET_LIKES_OF_USER,
    GET_PAGE_COMMENTS,
    GET_REECOMMEND
} from './ApiParameteres'

export const GetRecommendDescript = async (id) => {
    const response = await axios.get(API_URL + GET_REECOMMEND, {
        headers: {
            "Authorization": `Bearer ${getJwt()}`
        },
        params: {
            id: id
        }
    })
    return response;
}

export const GetLikesOfUser = async (userId) => {
    const response = await axios.get(API_URL + GET_LIKES_OF_USER, {
        params: {
            userId: userId
        }
    })
    return response;
}

export const GetCommentCount = async (recommendId) => {
    const response = await axios.get(API_URL + GET_COMMENTS, {
        headers: {
            "Authorization": `Bearer ${getJwt()}`
        },
        params: {
            id: recommendId
        }
    });
    return response;
}

export const GetPageOfComments = async (recommendId, pageNumber, pageSize) => {
    const response = await axios.get(API_URL + GET_PAGE_COMMENTS, {
        headers: {
            "Authorization": `Bearer ${getJwt()}`
        },
        params: {
            recommendId: recommendId,
            pageNum: pageNumber,
            pageSize: pageSize
        }
    })
    return response;
}