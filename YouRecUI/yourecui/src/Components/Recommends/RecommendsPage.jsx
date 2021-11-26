import { React, Component } from 'react';
import RecomendsList from './RecommendsList/RecommendsList';
import TagsCloud from './TagCloud/TagsCloud';

class RecommendsPage extends Component {
    constructor() {
        super();
        this.state = {

        }
    }

    componentDidMount() {

    }

    //TODO:     send query and fill state, then put into lists with props
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