import { React, Component } from 'react';
import RecenlyPublishedList from './RecentlyPublishList/RecentlyPublishedList';
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
                <RecenlyPublishedList />


                <hr/>
                <TagsCloud />
            </>
        );
    }

}

export default RecommendsPage;