import { faStar } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React, { useEffect, useState } from 'react';
import Rating from 'react-rating';
import { useSelector } from 'react-redux';
import { AddLike, AddRating, GetRecommendUserRating } from '../../Api/ApiRating';

export default function RecommendRate(props) {

    const userId = useSelector(state => state.userId);
    const [isLiked, setIsLiked] = useState(false);
    const [isRated, setIsRated] = useState(false);
    const [rating, setRating] = useState(0);

    useEffect(() => {
        GetRecommendUserRating(userId, props.recommendId).then(data => {
            setIsLiked(data.data.isLiked)
            setIsRated(data.data.isRated);
            if (isRated) setRating(data.data.ratingValue);
        })

    }, [props.recommendId, isLiked, isRated, rating, userId]);

    const rateHandler = (rating) => {
        AddRating(userId, props.recommendId, rating).then(data => {
            setIsRated(true);
        })
    }

    const likeHandler = () => {
        AddLike(userId, props.recommendId).then(data => {
            setIsLiked(true);
        })
    }

    return (
        <div className="h3 text-center m-4">
            You can rate this recommend
            <div className="row justify-content-center align-items-center mt-2">
                <Rating readonly={isRated} onChange={rateHandler} start={0} initialRating={rating} stop={5} step={1} emptySymbol={<FontAwesomeIcon className="text-muted h3" icon={faStar} />} fullSymbol={<FontAwesomeIcon className="text-warning h3" icon={faStar} />} />
                <button placeholder="You already liked it" disabled={isLiked} onClick={likeHandler} className="btn btn-success btn-lg ml-4">
                    Like!
                </button>
            </div>
        </div>
    );
}