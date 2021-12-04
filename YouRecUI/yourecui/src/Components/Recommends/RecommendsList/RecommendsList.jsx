import { React, useState, useEffect } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import RecommendItem from '../RecommendItem/RecommendItem';
import { Row } from 'react-bootstrap';
import { PICTURE_DEFAULT } from '../../../Api/ApiParameteres';

export function RecomendsList(props) {

    const [recommends, setRecommends] = useState([]);
    
    useEffect(() => {
        setRecommends(props.recommends)
    }, [props])

    return (
        <>
            <div>
                <Row xs={1} md={2} lg={3} xl={4} xxl={4} className="g-5 m-2">
                    {
                        recommends.map((item, index) => (
                            <RecommendItem key={index} id={item.id} title={item.name} text={item.text} PublishDateTime={item.creationDate} group={item.group} author={item.authorName} rating={item.averageUserRating} imageRef={item.images.length !== 0 ? item.images[0].original : PICTURE_DEFAULT}
                            />
                        ))
                    }
                </Row>
            </div>
        </>
    );


}

export default RecomendsList;