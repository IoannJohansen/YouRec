import axios from 'axios'
import {
    getJwt
} from '../Helper/jwtHelper';
import {
    API_URL,
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