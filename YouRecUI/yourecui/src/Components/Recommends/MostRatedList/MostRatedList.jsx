import { React, Component } from 'react'
import TagsCloud from '../TagCloud/TagsCloud';
import 'bootstrap/dist/css/bootstrap.min.css';
import RecommendItem from '../RecommendItem/RecommendItem';
import { Row } from 'react-bootstrap';

class MostRatedList extends Component {
    constructor() {
        super();
        this.state = {
            recommends: ["1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1"]
        }
    }

    render() {
        return (
            <div>
                <h2 className="text-center mt-2">Most rated published</h2>
                <Row xs={1} md={5} className="g-4 p-2 justify-content-around">
                    {
                        this.state.recommends.map(item => {
                            return (
                                <RecommendItem name="Johny" group="Game" text="Hello world!" imageRefs="https://cs13.pikabu.ru/post_img/2020/06/12/1/1591912947116769177.jpg" />
                            );
                        })
                    }
                </Row>

                <TagsCloud />
            </div>
        );
    }

}

export default MostRatedList;