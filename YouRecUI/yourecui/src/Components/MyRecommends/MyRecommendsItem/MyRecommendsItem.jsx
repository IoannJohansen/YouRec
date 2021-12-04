import moment from "moment";
import { React, Component } from "react";
import { ButtonGroup, Card, Col } from "react-bootstrap";
import CardHeader from "react-bootstrap/esm/CardHeader";
import { Link } from "react-router-dom";
import UserAvgRating from "../../RecommendDescriptionPage/UserAvgRating";
import "../../Recommends/RecommendItem/RecommendItem.css";
import Button from 'react-bootstrap/button';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEdit, faEye, faTractor, faTram, faTrash } from "@fortawesome/free-solid-svg-icons";
import { deleteRecommend } from "../../../Api/ApiMyRecommends";

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
      publishDate: moment(props.PublishDateTime).format("DD.MM.YYYY hh:mm"),
    };
  }



  render() {
    return (
      <Col className="mb-3">
        <Card
          style={{ textDecoration: "none" }}
          className="col-md-12 shadow h-100"
        >
          <Card.Img className="RecImage" src={this.state.imageRef}></Card.Img>
          <CardHeader>
            <Card.Title className="text-center text-truncate">
              {this.state.title}
            </Card.Title>
          </CardHeader>
          <Card.Footer className="text-muted">
            <div className="d-flex justify-content-between">
              <div className="h5 text-primary">
                <UserAvgRating rating={this.state.rating.toFixed(1)} />
              </div>
              <ButtonGroup>
                <Button variant="primary" size="md"><FontAwesomeIcon icon={faEdit} /></Button>
                <Button variant="primary" size="md"><FontAwesomeIcon icon={faEye} /></Button>
                <Button onClick={()=>this.props.selfRemover(this.props.id)} variant="danger" size="md"><FontAwesomeIcon icon={faTrash} /></Button>
              </ButtonGroup>
            </div>
            <p className="m-0 text-muted text-left small">
              {this.state.publishDate}
            </p>
          </Card.Footer>
        </Card>
      </Col>
    );
  }
}

export default RecommendItem;
