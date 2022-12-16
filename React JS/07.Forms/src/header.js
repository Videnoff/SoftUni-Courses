import React from "react";
import {Link} from "react-router-dom";

const Header = () => {
    return (
        <div>
            <Link className="home-page-header" to="/">
                Home page
            </Link>
            <Link to="/search">
                Search page
            </Link>
        </div>
    )
}

export default Header;