import { createStore } from 'redux';
import { userReducer } from './Reducers/UserReducer/UserReducer';

export const store = createStore(userReducer);
store.subscribe(()=>console.log(store.getState()));