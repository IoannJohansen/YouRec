import Button from '@restart/ui/esm/Button';
import React, { useEffect, useState } from 'react';
import { Form } from 'react-bootstrap';
import { GetPageOfComments } from '../../Api/ApiRecommendPage';

export default function Comments(props) {

    //TODO: make query to api for comments
    //TODO: state with current page and page size + api

    const scrollHandler = (e) => {
        const windowRelativeBottom = document.documentElement.getBoundingClientRect().bottom;
        if (document.documentElement.clientHeight + 50 > windowRelativeBottom) {
            setFetching(true);

        }
        // console.log(document.documentElement.clientHeight >  boundariesCoordinates.bottom);
    }

    const [commentPageNumber, setCommentPageNumber] = useState(0);
    const [comments, setComments] = useState([]);
    const [fetching, setFetching] = useState(false);
    const PAGESIZE = 10;


    useEffect(() => {
        document.addEventListener('scroll', scrollHandler)

        return function () {
            document.removeEventListener('scroll', scrollHandler);
        }

    }, [props.id])


    useEffect(() => {
        if (fetching) {
            GetPageOfComments(props.id, commentPageNumber, PAGESIZE).then(data => {
                setComments([...comments, ...data.data.items]);
                console.log("Fetch")
            }).then(() => {
                setCommentPageNumber(commentPageNumber + 1);
            }).finally(() => {
                setFetching(false);
            })
        }

    }, [fetching])

    return (
        <div className="text-center column justiy-content-center" style={{ overflowWrap: 'break-word' }}>
            <p className="h3">
                Comments
            </p>
            <div className="d-flex m-auto col-md-5 col-sm-5" >

                <Form.Control style={{ height: "100px" }} as="textarea" placeholder="Leave a comment here" />
                <Button className="btn btn-primary" >Send</Button>
            </div>
            <div>
                {
                    comments.map((item, index) => (
                        <div className="mt-3" key={index}>
                            <p className="h4">{item.username}</p>
                            <p>{item.commentMessage}</p>
                        </div>
                    ))
                }
            </div>
        </div>
    );
}