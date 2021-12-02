import React, { useState } from 'react';
import 'react-dropzone-uploader/dist/styles.css'
import Dropzone from 'react-dropzone-uploader'

export default function ImageLoader(props) {

    const handleChangeStatus = ({ meta, remove }, status) => {
        switch (status) {
            case 'done':
                if ((meta.width / meta.height).toFixed(1) < 1.7 || (meta.width / meta.height).toFixed(1) > 1.8) {
                    props.errorMessageSetter("Invalid format");
                    remove()
                } else {
                    props.errorMessageSetter("");
                }
                break;
            default:
                break;
        }
    }

    const handleSubmit = (files) => {
        props.imageSetter(files);
    }

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