import { React, Component } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import RecommendItem from '../RecommendItem/RecommendItem';
import { Row } from 'react-bootstrap';

class RecomendsList extends Component {
    constructor() {
        super();
        this.state = {
            recommends: ["1", "1", "1", "1", "1" , "1"]
        }
    }

    render() {
        return (
            <div>
                <Row xs={1} md={2} lg={4} className="g-4 m-2 d-flex ">
                    {
                        this.state.recommends.map(item => {
                            return (
                                <RecommendItem name="Johny" group="Game" text="Hello world!" imageRefs="https://cs13.pikabu.ru/post_img/2020/06/12/1/1591912947116769177.jpg" />
                            );
                        })
                    }
                </Row>
            </div>
        );
    }

}

export default RecomendsList;