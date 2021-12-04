import React, { useEffect, useState } from "react";
import MyRecommendsList from "./MyRecommendsList/MyRecommendsList";
import { Button, ButtonGroup, Form } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faArrowDown,
  faArrowUp,
  faFilter,
  faSearch,
} from "@fortawesome/free-solid-svg-icons";
import { getForUser, getSorted } from "../../Api/ApiMyRecommends";
import { useSelector } from "react-redux";

export default function MyRecommendsPage() {
  const [myRecommends, setMyRecommends] = useState([]);
  const [recommendPageNumber, setrecommendPageNumber] = useState(0);
  const [fetching, setFetching] = useState(true);
  const [totalCount, setTotalCount] = useState(1);
  const [sortOrder, setSortOrder] = useState("asc");
  const PAGESIZE = 12;
  const [sortMode, setSortMode] = useState("1");
  const userId = useSelector((store) => store.userId);

  useEffect(() => {
    getForUser(userId, recommendPageNumber, PAGESIZE).then((data) => {
      setMyRecommends(data.data.recommends);
      setTotalCount(data.data.maxCount);
    });
  }, [userId]);

  // const scrollHandler = (e) => {
  //     const windowRelativeBottom = document.documentElement.getBoundingClientRect().bottom;
  //     if ((document.documentElement.clientHeight + 100 > windowRelativeBottom) && totalCount > myRecommends.length) {
  //         setFetching(true);
  //     }
  // }

  // useEffect(() => {
  //     document.addEventListener('scroll', scrollHandler)
  //     return function () {
  //         document.removeEventListener('scroll', scrollHandler);
  //     }
  // }, [])

  // useEffect(() => {
  //     if (fetching) {

  //         // GetPageOfComments(props.id, commentPageNumber, PAGESIZE).then(data => {
  //         //     if (data.status === 204) return;
  //         //     setComments([...comments, ...data.data.items]);
  //         //     setCommentPageNumber(commentPageNumber => commentPageNumber + 1);
  //         //     setTotalCount(data.data.itemCount);
  //         // }).finally(() => {
  //         //     setFetching(false);
  //         // })
  //     }

  // }, [fetching])

  const sortModeClickHandle = () => {
    setSortOrder(sortOrder === "asc" ? "desc" : "asc");
  };

  const sortModeChange = (e) => {
    setSortMode(e.target.value);
  };

  const getSortedRecommends = () => {
    getSorted(userId, sortOrder, sortMode, recommendPageNumber, PAGESIZE).then(
      (data) => {
        setMyRecommends(data.data.recommends);
        setTotalCount(data.data.maxCount);
      }
    );
  };

  const clearSortParameteres = () => {
    setSortMode(1);
    setSortOrder("desc");
  };

  return (
    <div>
      <div className="container justify-content-around d-flex">
        <div className="d-flex border border-primary p-2 justify-content-between col-md-6">
          <Button onClick={sortModeClickHandle}>
            <FontAwesomeIcon
              icon={sortOrder === "asc" ? faArrowUp : faArrowDown}
            />
          </Button>

          <Form.Control
            value={sortMode}
            onChange={sortModeChange}
            className="col-5"
            as="select"
            size="md"
          >
            <option disabled value="-1">
              Select sort type
            </option>
            <option value={1}>Name</option>
            <option value={2}>Average user rating</option>
            <option value={3}>Publish Date</option>
          </Form.Control>

          <ButtonGroup>
            <Button onClick={getSortedRecommends} className="bg-primary">
              <FontAwesomeIcon icon={faSearch} />
            </Button>
            <Button onClick={clearSortParameteres} className="bg-primary">
              <FontAwesomeIcon icon={faFilter} />
            </Button>
          </ButtonGroup>
        </div>
      </div>

      {!myRecommends.length ? (
        <p className="h2 text-muted text-center">There's no items uploaded</p>
      ) : (
        <MyRecommendsList recommends={myRecommends} />
      )}
    </div>
  );
}
