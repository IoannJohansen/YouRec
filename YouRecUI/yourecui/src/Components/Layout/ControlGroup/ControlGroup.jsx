import { React } from "react";
import {
  faCog,
  faUser,
  faStarOfLife,
  faSignInAlt,
  faSignOutAlt,
} from "@fortawesome/free-solid-svg-icons";
import { Nav, ButtonGroup, Button } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from "react-router-dom";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { logout } from "../../../Store/ActionCreators/UserActions/UserActions";
import { ClearJwt } from "../../../Helper/jwtHelper";
import { useNavigate } from "react-router-dom";

function ControlGroup(props) {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const signOutClick = () => {
    ClearJwt();
    dispatch(logout());
    navigate("/Recs");
  };

  return (
    <Nav>
      <ButtonGroup className="justify-content-center">
        {props.isAdmin ? (
          <Link className="text-light" to="/admin">
            <Button>
              <FontAwesomeIcon icon={faStarOfLife} />
            </Button>
          </Link>
        ) : null}
        {
          props.isLoggedIn ? (
            <Button
              variant="danger"
              onClick={() => signOutClick()}
              className="text-light"
            >
              <FontAwesomeIcon icon={faSignOutAlt} />
            </Button>
          ) : (
            <Link className="text-light" to="/SignIn">
              <Button>
                <FontAwesomeIcon icon={faSignInAlt} />
              </Button>
            </Link>
          )}
      </ButtonGroup>
    </Nav>
  );
}

export default ControlGroup;
