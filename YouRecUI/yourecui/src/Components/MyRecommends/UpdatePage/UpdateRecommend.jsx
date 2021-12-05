import React, { useEffect, useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import ImageLoader from '../../CreateRecommend/DropZone/ImageLoader';
import TagEditor from '../TagEditor/TagEditor';
import Rating from 'react-rating';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faStar } from '@fortawesome/free-solid-svg-icons';
import { useForm } from 'react-hook-form';
import { TitleValidationRiles } from '../../../Helper/Validator';
import { getAllGroups } from '../../../Api/ApiGroups';
import { useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';

import MarkdownIt from 'markdown-it';
import MdEditor from 'react-markdown-editor-lite';
import 'react-markdown-editor-lite/lib/index.css';
import { TagNamesToSuggestions, TagsToDto } from '../../../Converters/TagConverter';
import { useParams } from 'react-router-dom';
import { GetRecommendDescript, updateRecommend } from '../../../Api/ApiRecommends';
import { GetImageByUrl } from '../../../Api/ApiImage';
import Carousel from 'react-grid-carousel';
import ImageCarousel from '../../RecommendDescriptionPage/ImageCarousel';

export default function UpdateRecommend() {
    const {
        register,
        handleSubmit,
        formState: { errors } } = useForm();

    const mdParser = new MarkdownIt();
    const navigate = useNavigate();


    const userId = useSelector(state => state.userId);
    const [title, setTitle] = useState("");
    const [groups, setGroups] = useState([]);
    const [recommendText, setRecommendText] = useState("**Hello world!!!**");
    const [rating, setRating] = useState(0);
    const [selectedtags, setSelectedtags] = useState([]);
    const [selectedGroupValue, setSelectedGroupValue] = useState("");
    const [imageLinks, setImageLinks] = useState([]);
    const [imageErrMessage, setImageErrMessage] = useState("");
    const [tagErr, setTagErr] = useState("");
    const [newImageLinks, setNewImageLinks] = useState([]);
    const { id } = useParams();


    useEffect(() => {
        GetRecommendDescript(id).then(data => {
            const formatedTags = TagNamesToSuggestions(data.data.tags);
            setSelectedtags(formatedTags);
            setTitle(data.data.name);
            setRating(data.data.authorRating);
            setImageLinks(data.data.imageLinks);
            setRecommendText(data.data.text);
            setSelectedGroupValue(data.data.groupName);
        })
    }, [id])

    useEffect(() => {
        getAllGroups().then(data => {
            setGroups(data.data);
        })
    }, [])

    const submitHandler = () => {
        if (!selectedTagsValid()) return;
        let groupId = groups.filter(group => group.groupName === selectedGroupValue)[0].id;
        let tagDto = TagsToDto(selectedtags);
        updateRecommend(userId, title, recommendText, groupId, tagDto, newImageLinks, rating, id).then(data => {
            if (data.status === 200) {
                console.log(data);
                navigate("/Recs/" + id);
            }
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
        setSelectedGroupValue(event.target.value);
    }

    return (
        <div className="container mt-2">
            <div className="border-dark border p-1">
                <p className="h3 text-center">Update recommend</p>
                <div className="d-flex row p-3 justify-content-around mt-5 ">
                    <div className="col-xs-8 col-md-6 mb-2">
                        <div className="border border-dark ">
                            <ImageCarousel images={imageLinks} />
                        </div>
                        <br />
                        <ImageLoader imageLinks={newImageLinks} setImageLinks={setNewImageLinks} errorMessageSetter={setImageErrMessage} />
                        <p className="text-center text-danger">
                            {
                                imageErrMessage
                            }
                        </p>
                    </div>
                    <div className="align-center col-md-5">
                        {errors?.title && <p className="text-danger">{errors?.title?.message}</p>}
                        <label className="h6">Title</label>
                        <Form.Control vale="true" autoFocus maxLength={40} {...register("title", TitleValidationRiles)} size="md" value={title} onChange={event => setTitle(event.target.value)} type="text" placeholder="Title" />
                        <label className="mt-3 h6">Group</label>
                        <Form.Control
                            onChange={handleChangeDroupName}
                            as="select"
                            defaultChecked={3}
                            defaultValue={selectedGroupValue}
                            size="md"
                            className="mr-sm-2 mb-3"
                        >
                            <option disabled>Select group name</option>
                            {
                                groups.map((item, index) => (
                                    item.groupName === selectedGroupValue ? <option selected key={index} value={item.groupName}>{item.groupName}</option> : <option key={index} value={item.groupName}>{item.groupName}</option>
                                ))
                            }
                        </Form.Control>
                        <p className="text-center text-danger">
                            {
                                tagErr
                            }
                        </p>
                        <div className="mb-3">
                            <label className="h6">Tags</label>
                            <TagEditor selectedtags={selectedtags} tagSetter={setSelectedtags} />

                        </div>
                    </div>
                </div>
                <div className="m-4">
                    <MdEditor value={recommendText} style={{ height: '500px' }} renderHTML={text => mdParser.render(text)} onChange={e => setRecommendText(e.text)} />
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