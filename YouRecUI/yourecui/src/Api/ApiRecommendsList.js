import axios from 'axios'
import {
    getJwt
} from '../Helper/jwtHelper';
import {
    API_URL,
    MOST_RATED,
    RECENTLY_UPLOADED,
    TAG_LIST
} from './ApiParameteres'

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

export const getTagList = async () => {
    const response = await axios.get(API_URL + TAG_LIST);
    return response.data;
}