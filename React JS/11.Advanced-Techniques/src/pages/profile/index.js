import React, {useCallback, useContext, useEffect, useState} from 'react'
import PageLayout from '../../components/page-layout'
import Origamis from '../../components/origamis'
import UserContext from "../../Context";
import {useNavigate, useParams} from "react-router-dom";
import ErrorBoundary from "../../ErrorBoundary";

const ProfilePage = () => {

    const [username, setUsername] = useState(null);
    const [posts, setPosts] = useState(null);
    const context = useContext(UserContext);
    const params = useParams();
    const history = useNavigate();

    const logOut = () => {
        context.logOut();
        history('/');
    }

    const getData = useCallback(async () => {
        const id = params.userid;
        const response = await fetch(`http://localhost:9999/api/user?id=${id}`)

        if (!response.ok) {
            history('/error')
        } else {
            const user = await response.json();
            setUsername(user.username);
            setPosts(user.posts && user.posts.length);
        }
    }, [params.userid, history]);

    useEffect(() => {
        getData()
    }, [getData]);

    if (!username) {
        return (
            <PageLayout>
                <div>Loading....</div>
            </PageLayout>
        )
    }

    return (
        <PageLayout>
            <div>
                <p>User: {username}</p>
                <p>Posts: {posts}</p>

                <button onClick={logOut}>
                    Logout
                </button>
            </div>
            <ErrorBoundary>
                <Origamis length={3}/>
            </ErrorBoundary>
        </PageLayout>
    )
}

export default ProfilePage
