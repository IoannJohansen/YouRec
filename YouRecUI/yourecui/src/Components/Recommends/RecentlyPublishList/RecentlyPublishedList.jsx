import { React, Component } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import RecommendItem from '../RecommendItem/RecommendItem';
import { Row } from 'react-bootstrap';

class RecomendsList extends Component {
    constructor() {
        super();
        this.state = {
            recommends: ["1", "1", "1", "1", "1", "1"]
        }
    }

    render() {
        return (
            <div>
                <Row xs={1} md={2} lg={4} className="g-4 m-2 d-flex ">
                    {
                        this.state.recommends.map(item => {
                            return (
                                <RecommendItem name="Johny" group="Game" text="Hello world!" imageRefs="data:image/jpeg;base64,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" />
                            );
                        })
                    }
                </Row>
            </div>
        );
    }

}

export default RecomendsList;