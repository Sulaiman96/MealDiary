import React, { FC } from 'react';
import './hero.css';
import myImage from './images/app-food.jpg';
import { Link } from 'react-router-dom';
import { Button, Typography } from '@material-tailwind/react';

interface HeroProps { }

const Hero: FC<HeroProps> = () => (
    <div className="hero">
        <div className="container col-xxl-8 px-4 py-5">
            <div className="row flex-lg-row-reverse align-items-center g-5 py-5">
                <div className="col-10 col-sm-8 col-lg-6">
                    <img src={myImage} className="d-block mx-lg-auto img-fluid" alt="Bootstrap Themes"
                        width="500"
                        height="150" loading="lazy" />
                </div>
                <div className="col-lg-6">
                    <Typography variant='h1' className="display-5 fw-bold lh-1 mb-3">Track your meals. Discover new flavors.</Typography>
                    <Typography variant='paragraph'>The app for food enthusiasts. Capture your meals with ease, track your progress, and discover new
                        flavors.</Typography>
                    <div className="d-grid gap-2 d-md-flex justify-content-md-start">
                        <Link to={'/register'}>
                            <Button
                                className="rounded-full "
                                variant="filled"
                                color="black"
                                size="lg">
                                Get Started
                            </Button>
                        </Link>
                    </div>
                </div>
            </div>
        </div>
    </div>
);

export default Hero;
