import React from "react";

const AuthContext = React.createContext({
    loggedin: false,
    username: ''
});

export default AuthContext;