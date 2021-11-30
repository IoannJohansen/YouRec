import moment from 'moment';
import { React, Component } from 'react';
import { Card, Col } from 'react-bootstrap';
import CardHeader from 'react-bootstrap/esm/CardHeader';
import { Link } from 'react-router-dom';
import UserAvgRating from '../../RecommendDescriptionPage/UserAvgRating';
import './RecommendItem.css';


class RecommendItem extends Component {

    constructor(props) {
        super();
        this.state = {
            id: props.id,
            title: props.title,
            group: props.group,
            text: props.text,
            imageRef: props.imageRef,
            rating: props.rating,
            author: props.author,
            publishDate: moment(props.PublishDateTime).format("DD.MM.YYYY hh:mm")
        }
    }
    render() {

        return (
            <Col className="mb-3">
                <Link to={"./" + this.state.id} style={{ color: 'inherit', textDecoration: 'inherit' }}>
                    <Card style={{ textDecoration: 'none' }} className="col-md-12 shadow h-100">
                        <Card.Img className="RecImage" src={this.state.imageRef}></Card.Img>
                        <CardHeader>
                            <Card.Title className="text-center">{this.state.title}</Card.Title>
                        </CardHeader>
                        <Card.Body className="text-justify">
                            <p>
                                {this.state.text.length > 100 ? this.state.text.substr(0, 100).concat("...") : this.state.text}
                            </p>
                        </Card.Body>
                        <Card.Footer className="text-muted">
                            <div className="d-flex justify-content-between">
                                <div className="h5 text-primary">
                                    <UserAvgRating rating={this.state.rating.toFixed(1)} />
                                </div>
                                <div>
                                    {this.state.group}
                                </div>
                            </div>
                            <p className="m-0 text-muted text-center small">
                                {this.state.publishDate} | {this.state.author}
                            </p>
                        </Card.Footer>
                    </Card>
                </Link>
            </Col>
        );
    }

}

export default RecommendItem;