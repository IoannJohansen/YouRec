import { faStar } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import Button from '@restart/ui/esm/Button';
import moment from 'moment';
import React, { useEffect, useState } from 'react';
import { FloatingLabel, Form } from 'react-bootstrap';
import Rating from 'react-rating';
import { useSelector } from 'react-redux';
import { Link, useParams } from 'react-router-dom';
import { GetLikesOfUser, GetRecommendDescript } from '../../Api/ApiRecommendPage';
import AuthorInfo from './AuthorInfo';
import Comments from './Comments';
import ImageCarousel from './ImageCarousel';
import UserAvgRating from './UserAvgRating';

export default function RecommendDescriptionPage() {

    const { id } = useParams();
    const [title, settitle] = useState("");
    const [authorname, setAuthorname] = useState("");
    const [text, setText] = useState("");
    const [groupName, setGroupName] = useState("");
    const [imageLinks, setImageLinks] = useState([]);
    const [tags, setTags] = useState([]);
    const [comments, setComments] = useState([]);
    const [authorRating, setAuthorRating] = useState(0);
    const [creationDate, setCreationDate] = useState("");
    const [averageUserRating, setAverageUserRating] = useState("");
    const [authorLikes, setAuthorLikes] = useState(0);
    const [userId, setUserId] = useState("");


    //TODO: create component for comments

    useEffect(() => {
        GetRecommendDescript(id).then(data => {
            settitle(data.data.name)
            setImageLinks(data.data.imageLinks)
            setAuthorname(data.data.text);
            setText(data.data.text);
            setAuthorname(data.data.userName);
            setTags(data.data.tags);
            setGroupName(data.data.groupName)
            setCreationDate(moment(data.data.creationDate).format("DD.MM.YYYY hh:mm"));
            setAuthorRating(data.data.authorRating);
            setUserId(data.data.userId);
            setAverageUserRating(data.data.averageUserRating)
            setComments(data.data.comments);
        }).then(() => {
            GetLikesOfUser(userId).then(data => {
                setAuthorLikes(data.data);
            })
        });
    }, [id, creationDate, userId, authorLikes])

    return (
        <div className="p-2 m-0 w-100 d-flex row justify-content-center">
            <div className="col-lg-5 col-md-12 col-sm-12">
                <ImageCarousel images={imageLinks} />
            </div>
            <div className="col-lg-4 col-sm-12 col-xs-12 d-flex flex-column text-xs-right text-lg-right text-xs-center text-sm-center ">
                <p className="h3">{title} </p>
                <p className="text-muted h4">{groupName}</p>
                <p className="h4 mt-3">
                    Rating of post
                </p>
                <p><Rating start={0} readonly initialRating={averageUserRating} stop={5} step={1} emptySymbol={<FontAwesomeIcon className="text-muted h3" icon={faStar} />} fullSymbol={<FontAwesomeIcon className="text-primary h3" icon={faStar} />} /></p>
                <AuthorInfo authorName={authorname} authorLikes={authorLikes} />
            </div>
            <div className="containers col-lg-9">
                <p>{text}</p>
                <div>
                    <p className="h3 text-center">
                        My rating
                    </p>
                    <div className="col-sm-12 text-center">
                        <Rating start={0} readonly initialRating={authorRating} stop={10} step={1} emptySymbol={<FontAwesomeIcon className="text-muted h3" icon={faStar} />} fullSymbol={<FontAwesomeIcon className="text-warning h3" icon={faStar} />} />
                    </div>

                    <p className="h5 text-center mt-3">Tags:</p>
                    <div style={{ wordWrap: 'break-word' }}>
                        <p className="text-primary text-center">
                            {
                                [...tags].join(', ')
                            }
                        </p>
                    </div>

                </div>

                <Comments id={id} />

            </div>
        </div>
    )
}