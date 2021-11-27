import { React, useState, useEffect } from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import RecommendItem from '../RecommendItem/RecommendItem';
import { Row } from 'react-bootstrap';

export function RecomendsList(props) {

    const [recommends, setRecommends] = useState([]);

    useEffect(() => {
        console.log("List render");
        setRecommends(props.recommends)
        console.log(recommends);
    }, [props])

    return (
        <>
            <div>
                <Row xs={1} md={2} lg={3} xl={4} className="g-4 m-2 d-flex ">
                    {
                        ['1', '2', '3'].map((item, index) => (
                            <RecommendItem key={index} title="The Witcher 3: Wild Hunt" text="Перед выходом «Дикой Охоты» по сети пошла фотография одичавшего главы CD Projekt RED Марчина Ивинского с комментарием «вот, дескать, что с людьми несколько лет нечеловеческого труда и масштабной разработки делают».
                                        После марафонского забега в The Witcher 3: Wild Hunt я тоже чувствую себя выжатым лимоном. Перед глазами проносится космической мощи поток пережитых событий. Здесь ты один перед незнакомым миром, полным опасностей и тайн, мчишься бесконечно на волне приключений по городам и весям.
                                        После этого становится как-то неловко рассуждать про целостность повествования, ценность для жанра и секс на чучеле единорога. Важно только самое главное: друзья, это поистине была дикая охота.
                                        И вот почему." PublishDateTime={Date.now().toLocaleString()} group="Games" author="Иван Александрович" rating={4.5} imageRef="https://i.guim.co.uk/img/static/sys-images/Guardian/Pix/pictures/2015/5/12/1431449685079/3820d973-b176-4461-8445-bea76994820d-1020x612.png?width=445&quality=45&auto=format&fit=max&dpr=2&s=eba51bbc1779f5a008adbbdce304ad13"
                            />
                        )
                        )
                    }
                </Row>
            </div>
        </>
    );


}

export default RecomendsList;