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
                <Tab active={false} title="Select recommends">
                </Tab>
                <Tab eventKey="Recently uploaded" title="Recently uploaded">
                    <Tab.Container>
                        <RecomendsList recommends={recentlyUploaded.recommends} />

                    </Tab.Container>
                </Tab>
                <Tab eventKey="Most rated" title="Most rated">
                    <RecomendsList recommends={mostRated.recommends} />
                </Tab>
                <Tab eventKey="Tags" title="Tags">
                    <TagsCloud />
                </Tab>
            </Tabs>
        </>
    );
}

export default RecommendsPage;