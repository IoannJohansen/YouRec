import { React, useContext } from 'react';
import { faCog, faUser, faStarOfLife, faSignInAlt, faSignOutAlt } from '@fortawesome/free-solid-svg-icons';
import { Nav, ButtonGroup, Button } from 'react-bootstrap';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from 'react-router-dom';
import { UserContext } from '../../App/App';

function ControlGroup(props) {

    const userContext = useContext(UserContext);

    const signOutClick = () => {
        localStorage.removeItem("jwt");
        userContext.setInitState(false, false, "Guest");
    }

    return (
        <Nav>
            <ButtonGroup>
                <Link className="btn btn-primary text-light" to="/"><FontAwesomeIcon icon={faCog} /></Link>
                <Link className="btn btn-primary text-light" to="/"><FontAwesomeIcon icon={faUser} /></Link>
                {props.isAdmin ? <Button><Link className="text-light" to="/"><FontAwesomeIcon icon={faStarOfLife} /></Link></Button> : null}
                {props.isLoggedIn ? <Button variant="danger" onClick={() => signOutClick()} className="text-light"><FontAwesomeIcon icon={faSignOutAlt} /></Button> : <Link className="btn btn-primary text-light" to="/SignIn"><FontAwesomeIcon icon={faSignInAlt} /></Link>}
            </ButtonGroup>
        </Nav>
    );
}

export default ControlGroup;