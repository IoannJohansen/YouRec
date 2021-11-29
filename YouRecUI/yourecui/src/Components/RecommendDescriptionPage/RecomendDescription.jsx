import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { GetRecommendDescript } from '../../Api/ApiRecommendPage';
import ImageCarousel from './ImageCarousel';

export default function RecommendDescriptionPage() {

    const { id } = useParams();
    const [title, settitle] = useState("");
    const [authorname, setAuthorname] = useState("");
    const [text, setText] = useState("");
    const [groupName, setGroupName] = useState("");
    const [imageLinks, setImageLinks] = useState([]);
    const [tags, setTags] = useState([]);
    const [comments, setComments] = useState([]);
    const [ratings, setRatings] = useState([]);
    const [setAuthorRating] = useState(0);
    const [creationDate, setCreationDate] = useState("");

    useEffect(() => {
        GetRecommendDescript(id).then(data => {
            settitle(data.data.name)
            setImageLinks(data.data.imageLinks)
            setAuthorname(data.data.text);
            setText(data.data.text);
            setAuthorname(data.data.userName);

        })
    }, [id])

    console.log(imageLinks);

    return (
        <>
            <div className="mt-3 row d-flex">
                <div className="col-lg-6 col-sm-8 ">
                    <ImageCarousel images={imageLinks} />
                </div>
                <div className="col-lg-6 col-sm-8 text-center">
                    <p className="h1">{title}</p>
                </div>
            </div>

            <p>{text}</p>
        </>
    )
}