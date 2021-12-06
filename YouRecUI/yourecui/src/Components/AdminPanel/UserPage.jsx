import React, { useEffect, useState } from 'react';
import { Row } from 'react-bootstrap';
import { useParams } from 'react-router';
import { PICTURE_DEFAULT } from '../../Api/ApiParameteres';
import { deleteRecommend, getRecommendsForUser } from '../../Api/ApiRecommends';
import RecommendItem from '../MyRecommends/MyRecommendsItem/MyRecommendsItem';

export default function UserPage() {

    const userId = useParams();
    const [recommends, setRecommends] = useState([]);
    const pageSize = 30;

    useEffect(() => {
        getRecommendsForUser(userId.id, 0, pageSize).then(data => {
            setRecommends(data.data.recommends)
        })
    }, [userId])

    const removeRecommend = (id) => {
        deleteRecommend(id).then(data => {
            if (data.status === 200) {
                const newRecommendList = recommends.filter(item => item.id !== id);
                setRecommends(newRecommendList);
            }
        }).catch(err => {
            console.log(err);
        })
    }

    return (
        <div>
            <div>
                {
                    recommends.length === 0 ? <p className="h2 text-muted text-center">There's no items uploaded</p> :
                        <Row xs={1} md={2} lg={3} xl={4} xxl={4} className="g-5 m-2">
                            {recommends.map((item) => (
                                <RecommendItem
                                    key={item.id}
                                    id={item.id}
                                    title={item.name}
                                    text={item.text}
                                    PublishDateTime={item.creationDate}
                                    group={item.group}
                                    author={item.authorName}
                                    rating={item.averageUserRating}
                                    selfRemover={removeRecommend}
                                    imageRef={
                                        item.images.length !== 0
                                            ? item.images[0].original
                                            : PICTURE_DEFAULT
                                    }
                                />
                            ))
                            }
                        </Row>
                }
            </div>
        </div>
    )
}