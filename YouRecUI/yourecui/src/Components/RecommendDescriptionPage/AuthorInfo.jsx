import React, { useEffect, useState } from 'react'
import { GetLikesOfUser } from '../../Api/ApiLike';

export default function AuthorInfo(props) {

    const [authorLikes, setAuthorLikes] = useState(0);

    useEffect(() => {
        
        GetLikesOfUser(props.userId).then(data => {
            setAuthorLikes(data.data);
        })
    }, [props.userId])

    return (
        <div>
            <p className="h4">Author: </p>
            <p className="h5 text-primary">{props.authorName}, {authorLikes} likes</p>
        </div>
    );
}