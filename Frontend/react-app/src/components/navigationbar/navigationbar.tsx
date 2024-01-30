import React, { FC } from 'react';
import './navigationbar.css';
import {Container, Navbar, Nav, Button} from "react-bootstrap";
import logo from './icons/logo.svg';

interface NavigationbarProps {}

const Navigationbar: FC<NavigationbarProps> = () => (
  <div className="navigationbar">
      <Navbar bg="dark" data-bs-theme="dark" expand="lg" className="bg-body-tertiary" sticky="top">
          <Container>
              <Navbar.Brand href="#home">
                  <img  src={logo} alt='logo'/>
              </Navbar.Brand>
              <Navbar.Toggle/>
              <Navbar.Collapse>
                  <Nav className="ms-auto">
                      <Nav.Link href="#features" className="white-nav-link">Features</Nav.Link>
                      <Nav.Link href="#pricing" className="white-nav-link">Pricing</Nav.Link>
                      <Nav.Link href="#about" className="white-nav-link">About</Nav.Link>
                      <Nav.Link href="#contact" className="white-nav-link">Contact</Nav.Link>
                  </Nav>
              </Navbar.Collapse>
          </Container>
      </Navbar>
  </div>
);

export default Navigationbar;
