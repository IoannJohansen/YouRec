import React, { useEffect, useState } from 'react';
import 'react-dropzone-uploader/dist/styles.css';
import Dropzone from 'react-dropzone-uploader';
import { uploadImage } from '../../../Api/ApiImage';

export default function ImageLoader(props) {

    const [images, setImages] = useState([]);

    const handleChangeStatus = ({ meta, remove, file }, status) => {
        switch (status) {
            case 'done':
                if ((meta.width / meta.height).toFixed(1) < 1.7 || (meta.width / meta.height).toFixed(1) > 1.8) {
                    props.errorMessageSetter("Image must have 16:9 format");
                    remove()
                } else {
                    props.errorMessageSetter("");
                }
                break;

            case 'remove':
                remove();
                break;
            default:
                break;
        }
    }

    const handleSubmit = (files) => {
        setImages(files);
    }

    useEffect(() => {
        if (images.length !== 0) {
            let imageLinks = [];
            images.forEach(img => {
                uploadImage(img.file).then(data => {
                    imageLinks.push(data);
                })
            });
            props.setImageLinks(imageLinks);
        }
    }, [images])

    return (
        <div>
            <Dropzone
                autoUpload={true}
                maxFiles={3}
                inputContent="Drop 3 Images"
                inputWithFilesContent={files => `${3 - files.length} more`}
                onChangeStatus={handleChangeStatus}
                onSubmit={handleSubmit}
                accept="image/*"
            />
        </div>
    );
}