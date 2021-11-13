import { React, Component } from 'react';
import RecomendsList from './RecentlyPublishList/RecentlyPublishedList';
import TagsCloud from './TagCloud/TagsCloud';

class RecommendsPage extends Component {
    constructor() {
        super();
        this.state = {

        }
    }

    render() {
        return (
            <>
                <h2 className="text-center m-4">Recently published</h2>
                <RecomendsList />
                <hr />
                <h2 className="text-center m-4">Most rated</h2>
                <RecomendsList />
                <hr />
                <TagsCloud />
            </>
        );
    }

}

export default RecommendsPage;