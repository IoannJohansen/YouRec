import { React, Component } from 'react';
import { faCog, faUser, faSignOutAlt, faStarOfLife } from '@fortawesome/free-solid-svg-icons';
import { Nav, Button, ButtonGroup } from 'react-bootstrap';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

class ControlGroup extends Component {

    constructor(props) {
        super()
        this.state = {
            isLoggedIn: props.isLoggedIn,
            isAdmin: props.isAdmin
        }
    }

    renderAdminButton = () => this.state.isAdmin ? <Button variant="warning" ><FontAwesomeIcon icon={faStarOfLife} /></Button> : null

    renderSignInbutton = () => this.state.isLoggedIn ? <Button variant="success" ><FontAwesomeIcon icon={faSignOutAlt} /></Button> : <Button variant="danger" ><FontAwesomeIcon icon={faSignOutAlt} /></Button>

    render() {
        return (
            <Nav>
                <ButtonGroup>
                    <Button variant="primary"><FontAwesomeIcon icon={faCog} /></Button>
                    <Button ><FontAwesomeIcon icon={faUser} /></Button>
                    {this.renderAdminButton()}
                    {this.renderSignInbutton()}
                </ButtonGroup>
            </Nav>
        );
    }
}

export default ControlGroup;