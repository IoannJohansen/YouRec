import { faUsers } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { React, Component } from 'react';
import { Card, Col } from 'react-bootstrap';
import CardHeader from 'react-bootstrap/esm/CardHeader';
import './RecommendItem.css';

class RecommendItem extends Component {

    constructor(props) {
        super();
        this.state = {
            title: props.title,
            group: props.group,
            text: props.text,
            imageRef: props.imageRef,
            rating: props.rating,
            author: props.author,
            publishDate: props.PublishDateTime
        }
    }

    render() {

        return (
            <Col className="mb-3">
                <Card className="col-md-12 shadow h-100">
                    <Card.Img style={{ width: "auto", height: "200px", minWidth: "50px", maxWidth: "1200px", minHeight: "50px", maxHeight: "1200px" }} className="mt-4" src={this.state.imageRef}></Card.Img>
                    <CardHeader>
                        <Card.Title className="text-center">{this.state.title}</Card.Title>
                    </CardHeader>
                    <Card.Body>
                        <p className="text-left">
                            {this.state.text.length > 70 ? this.state.text.substr(0, 70).concat("...") : this.state.text}
                        </p>
                    </Card.Body>
                    <Card.Footer className="text-muted">
                        <div className="d-flex justify-content-between">
                            <div className="h5 text-primary">
                                <FontAwesomeIcon icon={faUsers} />
                                <span className="ml-1">
                                    {this.state.rating}/5
                                </span>
                            </div>
                            <div>
                                {this.state.group}
                            </div>
                        </div>
                        Published: {this.state.publishDate} by {this.state.author}
                    </Card.Footer>
                </Card>
            </Col>
        );
    }

}

export default RecommendItem;