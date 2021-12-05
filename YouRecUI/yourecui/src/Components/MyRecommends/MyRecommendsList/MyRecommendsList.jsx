import { React, useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import RecommendItem from "../MyRecommendsItem/MyRecommendsItem";
import { Row } from "react-bootstrap";
import { PICTURE_DEFAULT } from "../../../Api/ApiParameteres";
import { deleteRecommend } from "../../../Api/ApiRecommends";



export const RecomendsList = (props) => {

  const [recommendList, setRecommendList] = useState([]);

  const removeRecommend = (id) => {
    deleteRecommend(id).then(data => {
      if (data.status === 200) {
        const newRecommendList = recommendList.filter(item => item.id !== id);
        setRecommendList(newRecommendList);
      }
    }).catch(err => {
      console.log(err);
    })
  }

  useEffect(() => {
    setRecommendList(props.recommends);
  }, [props.recommends])

  return (
    <>
      <div>
        {
          recommendList.length === 0 ? <p className="h2 text-muted text-center">There's no items uploaded</p> :
            <Row xs={1} md={2} lg={3} xl={4} xxl={4} className="g-5 m-2">
              {recommendList.map((item) => (
                <RecommendItem
                  key={item.id}
                  id={item.id}
                  title={item.name}
                  text={item.text}
                  PublishDateTime={item.creationDate}
                  group={item.group}
                  author={item.authorName}
                  rating={item.averageUserRating}
                  selfRemover={removeRecommend}
                  imageRef={
                    item.images.length !== 0
                      ? item.images[0].original
                      : PICTURE_DEFAULT
                  }
                />
              ))
              }
            </Row>
        }
      </div>
    </>
  )
};

export default RecomendsList;
