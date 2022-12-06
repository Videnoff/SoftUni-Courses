import React from "react";
import logo from './logo.svg';
import './App.css';
import {Link} from "react-router-dom";

function HomePage(props) {

    console.log('Match: ', props.match)
    console.log('Location: ', props.location)
    console.log('History: ', props.history)

    return (
        <div className="App">
            <header className="App-header">
                <img src={logo} className="App-logo" alt="logo"/>
                <p>
                    Home Page
                </p>
                <Link to="/search">
                    Go to search
                </Link>
                <a
                    className="App-link"
                    href="https://reactjs.org"
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Learn React
                </a>
            </header>
        </div>
    );
}

export default HomePage;
