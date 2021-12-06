import Button from '@restart/ui/esm/Button';
import React, { useEffect, useState } from 'react';
import { Table } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { getUsers } from '../../Api/ApiAdmin';


export default function AdminPage() {

    const [userList, setUserList] = useState([]);
    const [currentPageNum, setCurrentPageNum] = useState(0);
    const pageSize = 20;

    useEffect(() => {
        getUsers(currentPageNum, pageSize).then(data => {
            setUserList(data.data.users);
        })
    }, [])

    return (
        <div>
            <p className="text-center h2 m-4">Users</p>
            {userList.length !== 0 ?
                <Table className="container table" striped hover responsive-xs bordered>
                    <thead >
                        <tr className="text-center row">
                            <td className="col">Username</td>
                            <td className="col">email</td>
                            <td className="col"></td>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            userList.map((item, index) => (
                                <tr className="row text-center">
                                    <td className="col">{item.userName}</td>
                                    <td className="col">
                                        <Link style={{ color: 'inherit', textDecoration: 'inherit', width: 'inherit' }} to={"/admin/" + item.id} key={item.id}>
                                            <Button className="btn btn-primary">Watch recs</Button>
                                        </Link></td>
                                    <td className="col">
                                        <Link style={{ color: 'inherit', textDecoration: 'inherit', width: 'inherit' }} to={"/create/" + item.id} key={item.id}>
                                            <Button className="btn btn-primary">Create new rec</Button>
                                        </Link>
                                    </td>
                                </tr>
                            ))
                        }
                    </tbody>
                </Table> : <p>No registered users</p>
            }
        </div>
    );
}