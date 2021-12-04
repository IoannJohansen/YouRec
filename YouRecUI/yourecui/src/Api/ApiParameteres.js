const API_URL = "https://localhost:5001/api/";

//AUTHENTICATION
const SIGN_UP_PATH = "auth/SignUp";
const SIGN_IN_PATH = "auth/SignIn";
const SIGN_IN_TWITTER = "auth/twitter";
const SIGN_IN_GOOGLE = "auth/google";
const MICROSOFT_SIGN_IN = "auth/microsoft";
const CHECK_AUTH = "auth/checkauth";

//RECOMMEND LISTS
const RECENTLY_UPLOADED = "recommends/recentlyuploaded";
const MOST_RATED = "recommends/mostrated";
const GET_REECOMMEND = "recommends/getrecommend";
const ADD_RECOMMEND = "recommends/createpost";

//TAGS
const TAG_LIST = "tags/getalltags";

//LIKES 
const GET_LIKES_OF_USER = "like/getcountforuser";
const ADD_LIKE = "like/addLike";

//COMMENTS
const GET_COMMENTS = "comments/getcount";
const GET_PAGE_COMMENTS = "comments/getcommentpaged";
const ADD_COMMENT = "comments/addComment";

//RATING
const GET_RECOMMEND_USER_RATING = "rating/getRecommendUserInfo"
const ADD_RATING = "rating/addRating";

//API PUBLIC KEYS
const GOOGLE_CLIENT_ID = "467666703976-2v1pdp4p8v5rtho06lo6b5uvmv09jnfd.apps.googleusercontent.com";
const MICROSOFT_CLIENT_ID = "2a72ff00-fc7d-4aff-96ea-09f592f8dc1a";

// GROUPS
const GROUP_GET_ALL = "groups/getgroups";

//PICTURES
const PICTURE_DEFAULT = "https://images.hdqwalls.com/download/samsung-galaxy-s10-default-22-1920x1080.jpg";

//CLODUINARY
const CLOUDINARY_UPLOAD = "https://api.cloudinary.com/v1_1/dihtxymvr/upload";

//SOTYING AND FILTER
const GET_SORTED = "recommends/sort";
const GET_FOR_USER = "recommends/myrecommends";

module.exports = {
    API_URL,
    SIGN_IN_PATH,
    SIGN_UP_PATH,
    SIGN_IN_TWITTER,
    SIGN_IN_GOOGLE,
    MICROSOFT_SIGN_IN,
    GOOGLE_CLIENT_ID,
    MICROSOFT_CLIENT_ID,
    RECENTLY_UPLOADED,
    MOST_RATED,
    PICTURE_DEFAULT,
    TAG_LIST,
    GET_REECOMMEND,
    CHECK_AUTH,
    GET_LIKES_OF_USER,
    GET_COMMENTS,
    GET_PAGE_COMMENTS,
    GET_RECOMMEND_USER_RATING,
    ADD_LIKE,
    ADD_RATING,
    ADD_COMMENT,
    GROUP_GET_ALL,
    ADD_RECOMMEND,
    CLOUDINARY_UPLOAD,
    GET_SORTED,
    GET_FOR_USER
}