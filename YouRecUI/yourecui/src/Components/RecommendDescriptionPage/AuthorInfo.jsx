import { faThumbsUp } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React from 'react'

export default function AuthorInfo(props) {

    // {props.authorLikes}
    return (
        <div>
            <p className="h4">Author: </p>
            <p className="h5 text-primary">{props.authorName}, {props.authorLikes} likes</p>
        </div>
    );
}