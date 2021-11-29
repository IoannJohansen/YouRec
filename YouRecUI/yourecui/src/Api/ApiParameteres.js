const API_URL = "https://localhost:5001/api/";

const SIGN_UP_PATH = "auth/SignUp";
const SIGN_IN_PATH = "auth/SignIn";
const SIGN_IN_TWITTER = "auth/twitter";
const SIGN_IN_GOOGLE = "auth/google";
const MICROSOFT_SIGN_IN = "auth/microsoft";
const CHECK_AUTH = "auth/checkauth";

const RECENTLY_UPLOADED = "recommends/recentlyuploaded"
const MOST_RATED = "recommends/mostrated"
const GET_REECOMMEND = "recommends/getrecommend";

const TAG_LIST = "tags/getalltags"


const GOOGLE_CLIENT_ID = "467666703976-2v1pdp4p8v5rtho06lo6b5uvmv09jnfd.apps.googleusercontent.com";
const MICROSOFT_CLIENT_ID = "2a72ff00-fc7d-4aff-96ea-09f592f8dc1a";

const PICTURE_DEFAULT = "https://the-flow.ru/uploads/images/resize/830x0/adaptiveResize/03/60/25/27/70/661efde40cd7.jpg";

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
    CHECK_AUTH
}