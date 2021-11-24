import { faStarOfDavid } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { React, Component } from 'react';
import { Card, Col } from 'react-bootstrap';
import './RecommendItem.css';

class RecommendItem extends Component {
    constructor(props) {
        super();
        this.state = {
            title: props.title,
            group: props.group,
            tags: props.tags,
            text: props.text,
            imageRef: props.imageRef,
            rating: props.rating
        }
    }

    render() {

        return (
            <Col>
                <Card className="m-1 col-md-12 shadow-lg p-3 mb-5 bg-body">
                    <Card.Img variant="top" src={this.state.imageRef} />
                    <Card.Body>
                        <Card.Title>{this.state.title}</Card.Title>
                        <p className="text-justify">
                            {this.state.text.length > 300 ? this.state.text.substr(0, 100).concat("...") : this.state.text}
                        </p>
                        <div className="d-flex justify-content-between">
                            <div className="h3 m-0">
                                <FontAwesomeIcon className="text-warning" icon={faStarOfDavid} />
                                <span>
                                    {this.state.rating}/10
                                </span>
                            </div>
                            <div className="h5 text-right">
                                {this.state.group}
                            </div>
                        </div>
                    </Card.Body>
                    <Card.Footer className="font-weight-light">
                        Published: {this.props.PublishDateTime} by {this.props.author}
                    </Card.Footer>
                </Card>
            </Col>
        );
    }

}

export default RecommendItem;