import axios from 'axios'
import {
    API_URL,
    GET_LIKES_OF_USER,
} from './ApiParameteres'


export const GetLikesOfUser = async (userId) => {
    const response = await axios.get(API_URL + GET_LIKES_OF_USER, {
        params: {
            userId: userId
        }
    })
    return response;
}