import axios from 'axios'
import { API_URL, TAG_LIST } from './ApiParameteres';


export const getTagList = async () => {
    const response = await axios.get(API_URL + TAG_LIST);
    return response.data;
}