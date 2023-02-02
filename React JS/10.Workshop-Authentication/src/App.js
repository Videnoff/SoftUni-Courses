import React, {useEffect, useState} from "react";
import UserContext from "./Context";
import getCookie from "./utils/cookie";

const App = (props) => {
    const [user, setUser] = useState(null);
    const [loading, setLoading] = useState(true);

    const logIn = (user) => {
        setUser({
            ...user,
            loggedIn: true,
        })
    }

    const logOut = (user) => {
        document.cookie = "x-auth-token= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"
        setUser({
            loggedIn: false,
        })
    }

    useEffect(() => {
        // const token = getCookie('x-auth-token');
        const token = getCookie('x-auth-token; secure; SameSite=None');
        // document.cookie = `x-auth-token=${token}; secure; SameSite=None`;


        if (!token) {
            logOut();
            setLoading(false);
            return;
        }

        fetch('http://localhost9999/api/user/verify', {
            method: 'get',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': token,
                // 'Access-Control-Allow-Origin': '*',
            }
        }).then(promise => {
            console.log(promise);
            return promise.json();
        }).then(response => {
            if (response.status) {
                logIn({
                    username: response.user.username,
                    id: response.user._id,
                });
            } else {
                logOut();
            }

            setLoading(false);
        });

    }, []);

    // if (loading) {
    //     return (
    //         <div>
    //             Loading...
    //         </div>
    //     )
    // }

    return (
        <UserContext.Provider value={{
            user,
            logIn,
            logOut,
        }}>
            {props.children};
        </UserContext.Provider>
    )
}

export default App;
