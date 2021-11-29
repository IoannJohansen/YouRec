import { useEffect, useState } from 'react';
import { Image } from 'react-bootstrap';
import Carousel from 'react-grid-carousel'

export default function ImageCarousel(props) {
    const [images, setImages] = useState([]);

    useEffect(() => {
        setImages(props.images);
    }, [props.images, images]);

    return (
        <Carousel loop={true} autoplay={10000} cols={1}>
            {
                images.map((item, index) => (
                    <Carousel.Item key={index}>
                        <Image className="w-100" alt="Alt" src={item.original} />
                    </Carousel.Item>
                ))
            }
        </Carousel>
    )
}