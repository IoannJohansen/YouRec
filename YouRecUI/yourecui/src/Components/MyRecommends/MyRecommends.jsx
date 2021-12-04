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
      setFetching(true);
    }
  }, [userId]);

  const sortModeClickHandle = () => {
    setSortOrder(sortOrder === "asc" ? "desc" : "asc");
  };

  const sortModeChange = (e) => {
    setSortMode(e.target.value);
  };

  const getSortedRecommends = () => {
    getRecommendsSorted(
      userId,
      sortOrder,
      sortMode,
      recommendPageNumber,
      PAGESIZE
    ).then((data) => {
      setMyRecommends([...myRecommends, ...data.data.recommends]);
      setTotalCount(data.data.maxCount);
      setrecommendPageNumber(recommendPageNumber + 1);
    }).finally(() => {
      setFetching(false);
    });
  };

  useEffect(() => {
    setSortedAfterChangeMode();
  }, [sortMode, sortOrder]);

  const setSortedAfterChangeMode = () => {
    getRecommendsSorted(
      userId,
      sortOrder,
      sortMode,
      0,
      PAGESIZE).then(data => {
        setMyRecommends([...data.data.recommends]);
        setrecommendPageNumber(1);
      })
  }

  const clearSortParameteres = () => {
    setSortMode("1");
    setSortOrder("desc");
  };

  const scrollHandler = (e) => {
    const windowRelativeBottom =
      document.documentElement.getBoundingClientRect().bottom;
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
      getSortedRecommends();
    }
  }, [fetching]);

  return (
    <div>
      <div className="container justify-content-around d-flex p-1">
        <div className="d-flex p-0 justify-content-center col-md-6">
          <ButtonGroup>
            <Button onClick={sortModeClickHandle}>
              <FontAwesomeIcon
                icon={sortOrder === "asc" ? faArrowUp : faArrowDown}
              />
            </Button>
            <Button onClick={clearSortParameteres} className="bg-primary">
              <FontAwesomeIcon icon={faFilter} />
            </Button>
          </ButtonGroup>
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
