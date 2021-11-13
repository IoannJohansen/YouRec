import { React, Component } from 'react';
import { faCog, faUser, faSignOutAlt, faStarOfLife } from '@fortawesome/free-solid-svg-icons';
import { Nav, Button, ButtonGroup } from 'react-bootstrap';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from 'react-router-dom';


class ControlGroup extends Component {

    constructor(props) {
        super()
        this.state = {
            isLoggedIn: props.isLoggedIn,
            isAdmin: props.isAdmin
        }
    }

    renderAdminButton = () => this.state.isAdmin ? <Button variant="warning" ><FontAwesomeIcon icon={faStarOfLife} /></Button> : null

    renderSignInbutton = () => this.state.isLoggedIn ? <Link to="/SignIn" className="btn btn-success"><FontAwesomeIcon icon={faSignOutAlt} /></Link> : <Link to="/Recs" className="btn btn-danger" ><FontAwesomeIcon icon={faSignOutAlt} /></Link>

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