import axios from 'axios'
import {
    ADD_RECOMMEND,
    API_URL
} from './ApiParameteres'
import {
    GetJwtAuthHeader
} from '../Helper/jwtHelper'

export const addRecommend = async (formData) => {
    const response = await axios.post(API_URL + ADD_RECOMMEND, formData, {
        headers: GetJwtAuthHeader()
    })
    return response;
}