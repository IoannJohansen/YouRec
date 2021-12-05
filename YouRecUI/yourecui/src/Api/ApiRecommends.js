import axios from 'axios'
import {
    getJwt,
    GetJwtAuthHeader
} from '../Helper/jwtHelper';
import {
    ADD_RECOMMEND,
    API_URL,
    DELETE_RECOMMEND,
    GET_FOR_USER,
    GET_REECOMMEND,
    GET_SORTED,
    MOST_RATED,
    RECENTLY_UPLOADED,
    UPDATE_RECOMMEND
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

export const addRecommend = async (formData) => {
    const response = await axios.post(API_URL + ADD_RECOMMEND, formData, {
        headers: GetJwtAuthHeader()
    })
    return response;
}

export const getRecentlyUploaded = async () => {
    const response = await axios.get(API_URL + RECENTLY_UPLOADED, {
        headers: {
            'Authorization': `Bearer ${getJwt()}`
        }
    });
    return response.data;
}

export const getMostRated = async () => {
    const response = await axios.get(API_URL + MOST_RATED, {
        headers: {
            'Authorization': `Bearer ${getJwt()}`
        }
    });
    return response.data;
}

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

export const updateRecommend = async (userId, title, recommendText, groupId, tagDto, newImageLinks, rating, recommendId) => {
    const response = await axios.put(API_URL + UPDATE_RECOMMEND, {
        UserId: userId,
        name: title,
        text: recommendText,
        GroupId: groupId,
        Tags: tagDto,
        ImageLinks: newImageLinks,
        AuthorRating: rating,
        RecommendId: recommendId
    }, {
        headers: GetJwtAuthHeader()
    })
    return response;
}