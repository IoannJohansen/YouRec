import { React, useEffect, useState } from 'react';
import { Tab, Tabs } from 'react-bootstrap';
import { getMostRated, getRecentlyUploaded } from '../../Api/ApiRecommendsList';
import RecomendsList from './RecommendsList/RecommendsList';
import TagsCloud from './TagCloud/TagsCloud';

function RecommendsPage() {
    const [recentlyUploaded, setRecentlyUploaded] = useState({ currentCount: -1, recommends: [] });
    const [mostRated, setMostRated] = useState({ currentCount: -1, recommends: [] });

    useEffect(() => {
        getRecentlyUploaded().then(data => {
            setRecentlyUploaded(data);
        }).then(() => {
            getMostRated().then(data => {
                setMostRated(data);
            });
        })

    }, []);

    return (
        <>
            <Tabs transition defaultActiveKey="Recently uploaded" id="uncontrolled-tab-example" className="mb-3">
                <Tab eventKey="Recently uploaded" title="Recently uploaded">
                    {recentlyUploaded.currentCount <= 0 ? <p className="h2 text-muted text-center">There's no items uploaded</p> : <RecomendsList recommends={recentlyUploaded.recommends} />}
                </Tab>
                <Tab eventKey="Most rated" title="Most rated">
                    {mostRated.currentCount <= 0 ? <p className="h2 text-muted text-center">There's no items uploaded</p> : <RecomendsList recommends={mostRated.recommends} />}
                </Tab>
                <Tab eventKey="Tags" title="Tags">
                    <TagsCloud />
                </Tab>
            </Tabs>
        </>
    );
}

export default RecommendsPage;