import {
    CLOUDINARY_UPLOAD
} from "./ApiParameteres";

export const uploadImage = async (img) => {
    const data = new FormData();
    data.append('file', img);
    data.append('upload_preset', 'iez7lgap');
    const response = await fetch(CLOUDINARY_UPLOAD, {
        method: 'POST',
        body: data
    })

    const file = await response.json();
    return file.secure_url;
}

