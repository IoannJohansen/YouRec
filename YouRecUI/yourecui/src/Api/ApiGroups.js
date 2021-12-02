import axios from 'axios'
import {
    API_URL,
    GROUP_GET_ALL
} from './ApiParameteres'

export const getAllGroups = async () => {
    const response = await axios.get(API_URL + GROUP_GET_ALL)
    return response;
}