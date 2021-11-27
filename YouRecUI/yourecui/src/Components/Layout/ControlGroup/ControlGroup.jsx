import { React } from 'react';
import { faCog, faUser, faStarOfLife, faSignInAlt, faSignOutAlt } from '@fortawesome/free-solid-svg-icons';
import { Nav, ButtonGroup, Button } from 'react-bootstrap';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { useSelector } from 'react-redux';
import { logout } from '../../../Store/Actions/UserActions/UserActions';
import { ClearJwt } from '../../../Helper/jwtHelper';

function ControlGroup(props) {
    const dispatch = useDispatch();
    const isLoggedIn = useSelector(state => state.isLoggedIn);
    const isAdmin = useSelector(state => state.isAdmin);

    const signOutClick = () => {
        ClearJwt();
        dispatch(logout());
    }

    return (
        <Nav>
            <ButtonGroup>
                <Link className="btn btn-primary text-light" to="/"><FontAwesomeIcon icon={faCog} /></Link>
                <Link className="btn btn-primary text-light" to="/"><FontAwesomeIcon icon={faUser} /></Link>
                {isAdmin ? <Button><Link className="text-light" to="/"><FontAwesomeIcon icon={faStarOfLife} /></Link></Button> : null}
                {isLoggedIn ? <Button variant="danger" onClick={() => signOutClick()} className="text-light"><FontAwesomeIcon icon={faSignOutAlt} /></Button> : <Link className="btn btn-primary text-light" to="/SignIn"><FontAwesomeIcon icon={faSignInAlt} /></Link>}
            </ButtonGroup>
        </Nav>
    );
}

export default ControlGroup;