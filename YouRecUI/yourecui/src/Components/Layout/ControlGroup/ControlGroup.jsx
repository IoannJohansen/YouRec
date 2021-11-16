import { React, Component } from 'react';
import { faCog, faUser, faStarOfLife, faSignInAlt } from '@fortawesome/free-solid-svg-icons';
import { Nav, ButtonGroup, Button } from 'react-bootstrap';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from 'react-router-dom';

class ControlGroup extends Component {

    render() {
        return (
            <Nav>
                <ButtonGroup>
                    <Button><Link className="text-light" to={{ pathname: "/", state: { name: "hello world!" } }}><FontAwesomeIcon icon={faCog} /></Link></Button>
                    <Button><Link className="text-light" to="/"><FontAwesomeIcon icon={faUser} /></Link></Button>
                    <Button><Link className="text-light" to="/"><FontAwesomeIcon icon={faStarOfLife} /></Link></Button>
                    <Button><Link className="text-light" to="/SignIn"><FontAwesomeIcon icon={faSignInAlt} /></Link></Button>
                </ButtonGroup>
            </Nav>
        );
    }
}

export default ControlGroup;