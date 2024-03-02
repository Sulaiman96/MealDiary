import React from 'react'
import {
    Card,
    CardHeader,
    CardBody,
    CardFooter,
    Typography,
    Button,
} from "@material-tailwind/react";

interface Props { }

const MealDetailPage = (props: Props) => {
    return (
        <div className='h-screen flex items-center justify-center '>
            <Card className="mt-6 w-96">
                <CardHeader color="blue-gray" className="relative h-56">
                    <img
                        src="https://images.unsplash.com/photo-1595854341625-f33ee10dbf94?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        alt="card-image"
                    />
                </CardHeader>
                <CardBody>
                    <Typography variant="h5" color="blue-gray" className="mb-2">
                        Pizza
                    </Typography>
                    <Typography>
                        Lorem ipsum dolor, sit amet consectetur adipisicing elit. Quae obcaecati dolorum, libero fugiat expedita voluptatem facilis omnis iusto possimus exercitationem quidem et sequi saepe consectetur vel labore repudiandae nesciunt ipsam!
                    </Typography>
                </CardBody>
                <CardFooter className="pt-0">
                    <Button>Read More</Button>
                </CardFooter>
            </Card>
            <Card className="mt-6 w-96">
                <CardHeader color="blue-gray" className="relative h-56">
                    <img
                        src="https://images.unsplash.com/photo-1570877215023-229052e10c34?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        alt="card-image"
                    />
                </CardHeader>
                <CardBody>
                    <Typography variant="h5" color="blue-gray" className="mb-2">
                        Sushi Platter
                    </Typography>
                    <Typography>
                        Lorem ipsum dolor sit amet consectetur adipisicing elit. Enim earum voluptas nihil voluptate, maiores consequatur illo minima ducimus aperiam ipsa, consectetur quae mollitia dolorum iusto ipsum impedit! Enim, incidunt saepe?
                    </Typography>
                </CardBody>
                <CardFooter className="pt-0">
                    <Button>Read More</Button>
                </CardFooter>
            </Card>
            <Card className="mt-6 w-96">
                <CardHeader color="blue-gray" className="relative h-56">
                    <img
                        src="https://images.unsplash.com/photo-1520072959219-c595dc870360?q=80&w=1980&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                        alt="card-image"
                    />
                </CardHeader>
                <CardBody>
                    <Typography variant="h5" color="blue-gray" className="mb-2">
                        Vegan Burger
                    </Typography>
                    <Typography>
                        Lorem ipsum dolor sit amet consectetur, adipisicing elit. In ea molestias porro, temporibus reiciendis veritatis quas assumenda eos quos incidunt odio? Recusandae est voluptatibus culpa iure consectetur quae itaque ipsum?
                    </Typography>
                </CardBody>
                <CardFooter className="pt-0">
                    <Button>Read More</Button>
                </CardFooter>
            </Card>
        </div>
    )
}

export default MealDetailPage