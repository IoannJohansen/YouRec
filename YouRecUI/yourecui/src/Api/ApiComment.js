import axios from 'axios'
import {
    getJwt,
    GetJwtAuthHeader
} from '../Helper/jwtHelper';
import {
    ADD_COMMENT,
    API_URL,
    GET_COMMENTS,
    GET_PAGE_COMMENTS,
} from './ApiParameteres'

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
            numPage: pageNumber,
            pageSize: pageSize
        }
    })
    return response;
}

export const AddComment = async (userId, recommendId, commentValue) => {
    const response = await axios.post(API_URL + ADD_COMMENT, {
        UserId: userId,
        RecommendId: recommendId,
        CommentMessage: commentValue
    }, {
        headers: GetJwtAuthHeader()
    })
    return response;
}