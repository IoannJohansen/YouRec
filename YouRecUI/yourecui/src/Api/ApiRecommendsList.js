import axios from 'axios'
import {
    getJwt
} from '../Helper/jwtHelper';
import {
    API_URL,
    RECENTLY_UPLOADED
} from './ApiParameteres'

export const getMostRecentlyADded = async () => {
    const response = await axios.get(API_URL + RECENTLY_UPLOADED, {
        headers: {
            'Authorization': `Bearer ${getJwt()}`
        }
    });
    return response.data;
}