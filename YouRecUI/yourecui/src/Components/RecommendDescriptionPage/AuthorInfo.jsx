import { faThumbsUp } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React from 'react'

export default function AuthorInfo(props) {

    return (
        <div>
            <p className="h5 text-primary">
                {props.authorName}, <FontAwesomeIcon icon={faThumbsUp} />
                {props.authorLikes}
            </p>
        </div>
    );
}