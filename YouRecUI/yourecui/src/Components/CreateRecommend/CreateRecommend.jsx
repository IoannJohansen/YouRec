import React, { useEffect, useState } from 'react';
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

import MarkdownIt from 'markdown-it';
import MdEditor from 'react-markdown-editor-lite';
import 'react-markdown-editor-lite/lib/index.css';
import { TagsToDto } from '../../Converters/TagConverter';
import { useNavigate } from 'react-router-dom';

export default function CreateRecommend() {
    const {
        register,
        handleSubmit,
        formState: { errors } } = useForm();

    const mdParser = new MarkdownIt();

    const userId = useSelector(state => state.userId);
    const [title, setTitle] = useState("");
    const [groups, setGroups] = useState([]);
    const [recommendText, setRecommendText] = useState("**Hello world!!!**");
    const [rating, setRating] = useState(0);
    const [selectedtags, setSelectedtags] = useState([]);
    const [selectedGroupValue, setSelectedGroupValue] = useState(1);
    const [imageLinks, setImageLinks] = useState([]);
    const [imageErrMessage, setImageErrMessage] = useState("");
    const [tagErr, setTagErr] = useState("");
    const navigate = useNavigate()

    useEffect(() => {
        getAllGroups().then(data => {
            setGroups(data.data)
        })

    }, [])

    useEffect(() => {
        if (groups.length !== 0)
            setSelectedGroupValue(groups[0].id);
    }, [groups])

    const submitHandler = () => {
        if (!selectedTagsValid()) return;

        let tagDto = TagsToDto(selectedtags);

        const formData = {
            userId: userId,
            title: title,
            recommendText: recommendText,
            groupId: selectedGroupValue,
            tags: tagDto,
            imageLinks: imageLinks,
            rating: rating
        }

        console.log(formData)
        addRecommend(formData).then(data => {
            navigate("/Recs");
        }).catch(err => {
            console.log(err)
        })
    }

    const selectedTagsValid = () => {
        if (selectedtags.length === 0) {
            setTagErr("Recommend must contain at least 1 tag")
            return false;
        }
        return true;
    }

    const rateHandler = (rating) => {
        setRating(rating);
    }

    const handleChangeDroupName = (event) => {
        setSelectedGroupValue(groups[event.target.value - 1].id);
    }

    return (
        <div className="container mt-2">
            <div className="border-dark border p-1">
                <p className="h3 text-center">Create recommend</p>
                <div className="d-flex justify-content-around mt-5 ">
                    <div className="col-6">
                        <ImageLoader imageLinks={imageLinks} setImageLinks={setImageLinks} errorMessageSetter={setImageErrMessage} />
                        <p className="text-center text-danger">
                            {
                                imageErrMessage
                            }
                        </p>
                    </div>
                    <div className="align-center col-md-5">
                        {errors?.title && <p className="text-danger">{errors?.title?.message}</p>}
                        <Form.Control maxLength={40} {...register("title", TitleValidationRiles)} size="md" value={title} onChange={event => setTitle(event.target.value)} type="text" placeholder="Title" />

                        <Form.Control
                            onChange={handleChangeDroupName}
                            required
                            as="select"
                            size="md"
                            className="mr-sm-2 mt-3 mb-3"
                        >
                            <option disabled>Select group name</option>
                            {
                                groups.map((item, index) => (
                                    <option key={index} value={item.id}>{item.groupName}</option>
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
                    <MdEditor style={{ height: '500px' }} renderHTML={text => mdParser.render(text)} onChange={e => setRecommendText(e.text)} />
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