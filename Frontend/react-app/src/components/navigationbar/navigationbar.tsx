import React from 'react';
import { Container, Navbar, Nav } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import logo from './icons/logo.svg';

const Navigationbar = () => {
    return (
        <Navbar expand="lg" className="py-2 bg-stone-800 shadow-sm">
            <Container>
                <Navbar.Brand href="/" className="d-flex align-items-center">
                    <img src={logo} height="30" alt="logo" className="d-inline-block align-left" />
                    <div className='ms-2 text-white text-2xl'>Meal Diary</div>
                </Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ms-auto">
                        <LinkContainer to="/meal" className='text-white'>
                            <Nav.Link>Meals</Nav.Link>
                        </LinkContainer>
                        <LinkContainer to="/about" className='text-white'>
                            <Nav.Link>About</Nav.Link>
                        </LinkContainer>
                        <LinkContainer to="/pricing" className='text-white'>
                            <Nav.Link>Pricing</Nav.Link>
                        </LinkContainer>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
};

export default Navigationbar;