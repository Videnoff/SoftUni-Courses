import React from "react";
import logo from './logo.svg';
import './App.css';
import {Link} from "react-router-dom";
import Header from "./header";

function SearchPage() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Search Page
        </p>
        <Link to="/">
          Go to home page
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

export default SearchPage;
