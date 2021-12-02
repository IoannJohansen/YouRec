import React, { useState } from 'react';
import 'react-dropzone-uploader/dist/styles.css'
import Dropzone from 'react-dropzone-uploader'

export default function ImageLoader(props) {

    const handleChangeStatus = ({ meta, file }, status) => {
        //TODO: add validation for ersolution of image
        console.log("Changed " + status + " name: " + file);
    }

    const handleSubmit = (files) => {
        
        props.imageSetter(files);
    }

    return (
        <div>
            <Dropzone
                autoUpload={false}
                maxFiles={3}
                inputContent="Drop 3 Images"
                inputWithFilesContent={files => `${3 - files.length} more`}
                multiple={false}
                onChangeStatus={handleChangeStatus}
                onSubmit={handleSubmit}
                accept="image/*"
            />
        </div>
    );
}