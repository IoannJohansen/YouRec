import React, { useEffect, useState } from 'react';
import MDEditor from '@uiw/react-md-editor';
import { Form, Button } from 'react-bootstrap';
import ImageLoader from './DropZone/ImageLoader';
import TagController from './TagController/TagController';
import Rating from 'react-rating';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faStar } from '@fortawesome/free-solid-svg-icons';
import { useForm } from 'react-hook-form';
import { TitleValidationRiles } from '../../Helper/Validator';
import { getAllGroups } from '../../Api/ApiGroups';
import { addRecommend } from '../../Api/ApiCreateRecommend';
import { useSelector } from 'react-redux';
import { Dropbox } from 'dropbox';
import { CLOUDINARY_UPLOAD } from '../../Api/ApiParameteres'
import { uploadImage } from '../../Api/ApiImage';

export default function CreateRecommend() {

    const [title, setTitle] = useState("");
    const [recommendText, setRecommendText] = useState("You recommend text with markdown");
    const [images, setImages] = useState([]);
    const [rating, setRating] = useState(0);
    const [groups, setGroups] = useState([]);
    const [selectedGroupValue, setSelectedGroupValue] = useState();
    const [selectedtags, setSelectedtags] = useState([]);   // throw setter to tag component
    const [imageErrMessage, setImageErrMessage] = useState("");
    const [tagErr, setTagErr] = useState("");
    const [imageLinks, setImageLinks] = useState([]);
    const userId = useSelector(state => state.userId);

    const {
        register,
        handleSubmit,
        formState: { errors } } = useForm();

    const submitHandler = () => {
        if (!selectedTagsValid()) return;
        
        if (images.length !== 0) {
            images.forEach(img => {
                uploadImage(img.file).then(data => {
                    setImageLinks([...imageLinks, data]);
                })
            });
        }

        const formData = {
            userId: userId,
            title: title,
            reacommendText: recommendText,
            groupName: selectedGroupValue,
            tags: selectedtags,
            images: images,
            rating: rating
        }


        console.log(imageLinks);

        addRecommend(formData).then(data => {

            console.log(data);
        })
    }

    const selectedTagsValid = () => {
        if (selectedtags.length === 0) {
            setTagErr("Recommend must contain at least 1 tag")
            return false;
        }
        return true;
    }

    useEffect(() => {
        getAllGroups().then(data => {
            setGroups(data.data)
        })
    }, [])

    const rateHandler = (rating) => {
        setRating(rating);
    }

    const handleChangeDroupName = (event) => {
        setSelectedGroupValue(groups[event.target.value].groupName);
    }

    return (
        <div className="container">
            <div className="border-dark border p-1">
                <p className="h3 text-center">Create recommend</p>
                <div className="d-flex justify-content-around mt-5 ">
                    <div className="col-6">
                        <p className="text-center text-danger">
                            {
                                imageErrMessage
                            }
                        </p>
                        <ImageLoader errorMessageSetter={setImageErrMessage} imageSetter={setImages} />
                    </div>
                    <div className="align-center col-md-5">
                        {errors?.title && <p className="text-danger">{errors?.title?.message}</p>}
                        <Form.Control maxLength={40} {...register("title", TitleValidationRiles)} size="md" value={title} onChange={event => setTitle(event.target.value)} type="text" placeholder="Title" />

                        <Form.Control
                            onChange={handleChangeDroupName}
                            as="select"
                            size="md"
                            className="mr-sm-2 mt-3 mb-3"
                        >
                            <option disabled>Groupname</option>
                            {
                                groups.map((item, index) => (
                                    <option key={index} value={index}>{item.groupName}</option>
                                ))
                            }
                        </Form.Control>
                        <p className="text-center text-danger">
                            {
                                tagErr
                            }
                        </p>
                        <TagController tagSetter={setSelectedtags} />

                    </div>
                </div>
                <div className="m-4">
                    <MDEditor
                        className="h-100"
                        toolbarHeight="70"
                        preview="edit"
                        value={recommendText}
                        onChange={(event) => setRecommendText(event.target.value)}
                    />
                </div>

                <p className="h3 text-center mt-2">
                    Choose you rating
                </p>
                <div className="row justify-content-center align-items-center mt-2">
                    <Rating onChange={rateHandler} start={0} initialRating={rating} stop={10} step={1} emptySymbol={<FontAwesomeIcon className="text-muted h4" icon={faStar} />} fullSymbol={<FontAwesomeIcon className="text-warning h4" icon={faStar} />} />
                </div>

                <div className="text-right">
                    <Button onClick={handleSubmit(submitHandler)} className="btn btn-success btn-lg">Create</Button>
                </div>
            </div>
        </div>
    );
}