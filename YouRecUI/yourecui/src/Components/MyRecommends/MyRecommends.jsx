import React, { useEffect, useState } from "react";
import MyRecommendsList from "./MyRecommendsList/MyRecommendsList";
import { Button, ButtonGroup, Form } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faArrowDown,
  faArrowUp,
  faFilter,
} from "@fortawesome/free-solid-svg-icons";
import {
  getRecommendsForUser,
  getRecommendsSorted,
} from "../../Api/ApiMyRecommends";
import { useSelector } from "react-redux";

export default function MyRecommendsPage() {
  const userId = useSelector((store) => store.userId);
  const [myRecommends, setMyRecommends] = useState([]);
  const [recommendPageNumber, setrecommendPageNumber] = useState(0);
  const [fetching, setFetching] = useState(false);
  const [totalCount, setTotalCount] = useState(0);
  const [sortOrder, setSortOrder] = useState("asc");
  const [sortMode, setSortMode] = useState("1");
  const PAGESIZE = 20;

  useEffect(() => {
    if (userId.length !== 0) {
      // getRecommendsForUser(userId, recommendPageNumber, PAGESIZE).then((data) => {
      //   console.log(data.data);
      //   setMyRecommends(data.data.recommends);
      //   setTotalCount(data.data.maxCount);
      // });
      setFetching(true);
    }
  }, [userId]);

  const sortModeClickHandle = () => {
    setSortOrder(sortOrder === "asc" ? "desc" : "asc");
  };

  const sortModeChange = (e) => {
    setSortMode(e.target.value);
  };

  // useEffect(() => {
  //   getSortedRecommends();
  // }, [sortMode, sortOrder]);



  const getSortedRecommends = () => {
    getRecommendsSorted(
      userId,
      sortOrder,
      sortMode,
      recommendPageNumber,
      PAGESIZE
    ).then((data) => {
      console.log(data);
      setMyRecommends([...myRecommends, ...data.data.recommends]);
      setTotalCount(data.data.maxCount);
      setrecommendPageNumber(recommendPageNumber+1);
    }).finally(() => {
      setFetching(false);
    });
  };

  const clearSortParameteres = () => {
    setSortMode("1");
    setSortOrder("desc");
  };

  const scrollHandler = (e) => {
    const windowRelativeBottom =
      document.documentElement.getBoundingClientRect().bottom;
    console.log(myRecommends.length, totalCount);
    if (
      document.documentElement.clientHeight + 150 > windowRelativeBottom &&
      totalCount > myRecommends.length
    ) {
      setFetching(true);
    }
  };

  useEffect(() => {
    document.addEventListener("scroll", scrollHandler);
    return function () {
      document.removeEventListener("scroll", scrollHandler);
    };
  });

  useEffect(() => {
    if (fetching) {
      console.log("Fire!");

      getSortedRecommends();
      //   GetPageOfComments(props.id, commentPageNumber, PAGESIZE)
      //     .then((data) => {
      //       if (data.status === 204) return;
      //       setComments([...comments, ...data.data.items]);
      //       setCommentPageNumber((commentPageNumber) => commentPageNumber + 1);
      //       setTotalCount(data.data.itemCount);
      //     })
      //     .finally(() => {
      //       setFetching(false);
      //     });
    }
  }, [fetching]);

  return (
    <div>
      <div className="container justify-content-around d-flex">
        <div className="d-flex border border-primary p-2 justify-content-center col-md-6">
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
            <Button onClick={clearSortParameteres} className="bg-primary">
              <FontAwesomeIcon icon={faFilter} />
            </Button>
          </ButtonGroup>
        </div>
      </div>

      {!myRecommends.length === 0 ? (
        <p className="h2 text-muted text-center">There's no items uploaded</p>
      ) : (
        <MyRecommendsList recommends={myRecommends} />
      )}
    </div>
  );
}
