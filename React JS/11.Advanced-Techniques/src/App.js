import React, {useEffect, useState} from "react";
import UserContext from "./Context";
import getCookie from "./utils/cookie";

const App = (props) => {
    const [user, setUser] = useState(props.user || []);
    const origamis = props.origamis || [];

    const logIn = (userObject) => {
        setUser({
            ...userObject,
            loggedIn: true,
        })
    }

    const logOut = (user) => {
        document.cookie = "x-auth-token= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"
        setUser({
            loggedIn: false,
        })
    }

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
            origamis
        }}>
            {props.children};
        </UserContext.Provider>
    )
}

export default App;
