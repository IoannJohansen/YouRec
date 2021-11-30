import { Image } from 'react-bootstrap';
import Carousel from 'react-grid-carousel'
import { PICTURE_DEFAULT } from '../../Api/ApiParameteres';

export default function ImageCarousel(props) {
    
    return (
        props.images.length>0 ?
            <Carousel mobileBreakpoint={750} showDots loop={true} autoplay={10000} cols={1}>
                {
                    props.images.map((item, index) => (
                        <Carousel.Item key={index}>
                            <Image className="w-100" alt={PICTURE_DEFAULT} src={item.original} />
                        </Carousel.Item>
                    ))
                }
            </Carousel> : null
    )
}