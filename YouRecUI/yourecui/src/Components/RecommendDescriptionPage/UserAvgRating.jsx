import { faStar } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React, { useEffect, useState } from 'react';

export default function UserAvgRating(props) {

    const [rating, setRating] = useState(props.rating);

    useEffect(() => {
        setRating(props.rating)
    }, [props, rating])

    return (
        <>
            <span>
                <FontAwesomeIcon icon={faStar} />
                {rating}
            </span>
        </>
    );
}