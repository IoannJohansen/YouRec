import React from 'react';
import { faCog, faUser, faSignOutAlt, faStarOfLife } from '@fortawesome/free-solid-svg-icons';
import { Button, ButtonGroup } from 'react-bootstrap';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export default function ControlGroup() {
    return (
        <ButtonGroup>
            <Button variant="primary"><FontAwesomeIcon icon={faCog} /></Button>
            <Button ><FontAwesomeIcon icon={faUser} /></Button>
            <Button variant="warning disabled" ><FontAwesomeIcon icon={faStarOfLife} /></Button>
            <Button variant="danger" ><FontAwesomeIcon icon={faSignOutAlt} /></Button>
        </ButtonGroup>
    );
}