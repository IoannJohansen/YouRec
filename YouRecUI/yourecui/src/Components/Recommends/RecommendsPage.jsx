import { React, useEffect, useState } from 'react';
import { getMostRated, getRecentlyUploaded } from '../../Api/ApiRecommendsList';
import RecomendsList from './RecommendsList/RecommendsList';
import TagsCloud from './TagCloud/TagsCloud';

function RecommendsPage() {
    const [recentlyUploaded, setRecentlyUploaded] = useState({ currentCount: -1, recommends: [] });
    const [mostRated, setMostRated] = useState({ currentCount: -1, recommends: [] });

    useEffect(() => {
        getRecentlyUploaded().then(data => {
            setRecentlyUploaded(data);
        });

        getMostRated().then(data => {
            setMostRated(data);
        });
    }, []);

    return (
        <>
            <h2 className="text-center m-4">Recently published</h2>
            <RecomendsList recommends={recentlyUploaded.recommends} />
            <hr />
            <h2 className="text-center m-4">Most rated</h2>
            <RecomendsList recommends={mostRated.recommends} />
            <hr />
            <TagsCloud />
        </>
    );
}

export default RecommendsPage;