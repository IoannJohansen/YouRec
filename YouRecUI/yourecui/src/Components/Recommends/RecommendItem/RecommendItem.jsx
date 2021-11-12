import { React, Component } from 'react';
import { Card, Col } from 'react-bootstrap';
import './RecommendItem.css';

class RecommendItem extends Component {
    constructor(props) {
        super();
        this.state = {
            name: props.name,
            group: props.groups,
            tags: props.tags,
            text: props.text,
            imageRefs: props.imageRefs,
            rating: props.rating
        }
    }

    render() {
        return (
            <Col>
                <Card className="m-1 shadow-lg p-3 mb-5 bg-body rounded">
                    <Card.Img variant="top" src={this.props.imageRefs} />
                    <Card.Body>
                        <Card.Title>Card title</Card.Title>
                        <Card.Text>
                            This is a wider card with supporting text below as a natural lead-in to
                            additional content. This content is a little bit longer.
                        </Card.Text>
                    </Card.Body>
                    <Card.Footer>
                        Here will be rating
                    </Card.Footer>
                </Card>
            </Col>
        );
    }

}

export default RecommendItem;