import React from "react";
import logo from './logo.svg';
import './App.css';

const ProductPage = (props) => {

  const clickHandler = () => {
    props.history.push('/');
  }
  return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo"/>
          <p>
            Product Page: ID: {props.match.params.productid}
            Product Page: Name: {props.match.params.productname}
          </p>
          <button onClick={clickHandler}>
            Go to Home Page
          </button>
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

export default ProductPage;
