import Button from '@restart/ui/esm/Button';
import React, { useEffect, useState } from 'react';
import { Form } from 'react-bootstrap';
import { GetPageOfComments, AddComment } from '../../Api/ApiComment';

export default function Comments(props) {

    const scrollHandler = (e) => {
        const windowRelativeBottom = document.documentElement.getBoundingClientRect().bottom;
        if ((document.documentElement.clientHeight + 100 > windowRelativeBottom) && totalCount > comments.length) {
            setFetching(true);
        }
    }

    const [commentPageNumber, setCommentPageNumber] = useState(0);
    const [comments, setComments] = useState([]);
    const [fetching, setFetching] = useState(true);
    const [totalCount, setTotalCount] = useState(0);
    const [commentMessage, setCommentMessage] = useState("");
    const [errorComment, setErrorComment] = useState("");
    const PAGESIZE = 10;

    useEffect(() => {
        document.addEventListener('scroll', scrollHandler)
        return function () {
            document.removeEventListener('scroll', scrollHandler);
        }
    })

    useEffect(() => {
        if (fetching) {
            GetPageOfComments(props.id, commentPageNumber, PAGESIZE).then(data => {
                if (data.status === 204) return;
                setComments([...comments, ...data.data.items]);
                setCommentPageNumber(commentPageNumber => commentPageNumber + 1);
                setTotalCount(data.data.itemCount);
            }).finally(() => {
                setFetching(false);
            })
        }
    }, [fetching])

    const commentSendHandler = () => {
        if (commentMessage.length < 2) {
            setErrorComment("Comment must have length more then 1");
        } else {
            AddComment(props.userId, props.id, commentMessage).then(data => {
                setComments([...comments, data.data])
            }).finally(() => {
                setCommentMessage("");
            })
        }
    }

    return (
        <div className="text-center column justiy-content-center" style={{ overflowWrap: 'break-word' }}>
            <p className="h3">
                Comments
            </p>
            <p className="text-danger h5">
                {
                    errorComment
                }
            </p>
            <div className="d-flex m-auto col-md-5 col-sm-5" >
                <Form.Control value={commentMessage} onChange={(e) => setCommentMessage(e.target.value)} style={{ height: "100px" }} as="textarea" placeholder="Leave a comment here" />
                <Button onClick={commentSendHandler} className="btn btn-primary" >Send</Button>
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