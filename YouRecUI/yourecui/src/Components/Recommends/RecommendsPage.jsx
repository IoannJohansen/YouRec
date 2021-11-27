import { React, useEffect, useState } from 'react';
import { getMostRecentlyADded } from '../../Api/ApiRecommendsList';
import RecomendsList from './RecommendsList/RecommendsList';
import TagsCloud from './TagCloud/TagsCloud';

function RecommendsPage() {
    const [recentlyUploaded, setRecentlyUploaded] = useState({ currentCount: -1, recommends: [] });

    useEffect(() => {
        getMostRecentlyADded().then(data => {
            setRecentlyUploaded(data);
        })
        console.log("Page render");
    }, []);


    return (
        <>
            <h2 className="text-center m-4">Recently published</h2>
            <RecomendsList recommends={recentlyUploaded.recommends} />
            <hr />
            <h2 className="text-center m-4">Most rated</h2>
            {/* <RecomendsList /> */}
            <hr />
            <TagsCloud />
        </>
    );
}

export default RecommendsPage;