import React from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import { Button, Navbar, Nav, FormControl, DropdownButton, Dropdown, ButtonGroup } from 'react-bootstrap';

export default function App() {
  return (
    <div className="App">
      <Navbar className="justify-content-around" bg="dark" variant="dark">

        <Nav className="me-auto">
          <Nav.Link href="#1">
            Recommends
          </Nav.Link>
          <Nav.Link href="#2">
            Dva
          </Nav.Link>
          <Nav.Link href="#3">
            Tree
          </Nav.Link>
        </Nav>

        <Nav>
          <FormControl type="Search" aria-label="Search" placeholder="Search" className="me-2" />
        </Nav>

        <Nav>


          <ButtonGroup>
            <Button variant="danger">Войти</Button>

            <DropdownButton as={ButtonGroup} title="Profile">

              <Dropdown.Item>
                My Profile
              </Dropdown.Item>

              <Dropdown.Item>
                Settings
              </Dropdown.Item>

              <Dropdown.Item>
                Login/SignOut
              </Dropdown.Item>
            </DropdownButton>

          </ButtonGroup>
        </Nav>
      </Navbar>
    </div>
  );
}