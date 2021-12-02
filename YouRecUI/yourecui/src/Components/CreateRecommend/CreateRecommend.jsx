import React, { useEffect, useState } from 'react';
import MDEditor from '@uiw/react-md-editor';
import { Form, Button } from 'react-bootstrap';
import ImageLoader from './DropZone/ImageLoader';
import TagController from './TagController/TagController';

export default function CreateRecommend() {

    const [recommendText, setRecommendText] = React.useState("Type you recommend here");
    const [images, setImages] = useState([]);

    useEffect(() => {
        console.log("Rendered");
    }, [])

    const submitHandler = (e) => {
        e.preventDefault();
        console.log("Send");
    }

    //TODO: add field validation with useForm
    //TODO: take from outer setter for newTagz

    return (
        <div className="container">
            <Form className="border-dark border p-5">
                <p className="h2 text-center">Create recommend</p>

                <div className="d-flex justify-content-around mt-5 ">
                    <div className="col-5 mb-xs-4">
                        <ImageLoader imageSetter={setImages} />
                    </div>

                    <div className="align-center col-md-5">
                        <Form.Control size="md" type="text" placeholder="Title" />

                        <Form.Control
                            as="select"
                            size="md"
                            className="mr-sm-2 mt-4 mb-3"
                        >
                            <option selected disabled>Groupname</option>
                            {
                                [1, 23, 4, 5, 6, 7,].map((item, index) => (
                                    <option value={index}>Choose {index}</option>
                                ))

                            }
                        </Form.Control>

                        <TagController />


                    </div>
                </div>
                {/* <div className="container">
                    <MDEditor
                        value={recommendText}
                        onChange={setRecommendText}
                    />
                </div> */}

                {/* <Button onClick={submitHandler} className="btn btn-primary">Create</Button> */}
            </Form>
        </div>
    );
}