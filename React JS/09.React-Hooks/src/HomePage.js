import React, {Component, useEffect, useState} from "react";
import logo from './logo.svg';
import './App.css';
import {Link} from "react-router-dom";
import useCounter from "./hooks/usecounter";

const Home = () => {
    const {counter, handleClick} = useCounter(0);
    const [flag, setFlag] = useState(false);
    const [email, setEmail] = useState('');

    return (
        <div className="App">
            <header className="App-header">
                <p>
                    Home Page
                </p>
                <div>
                    <p>
                        Flag: {flag ? 'True' : 'False'}
                    </p>
                    <button onClick={() => setFlag(!flag)}>
                        Change flag
                    </button>
                </div>
                <div>
                    <p>
                        Counter: {counter}
                    </p>
                    <button onClick={handleClick}>
                        Click me
                    </button>
                </div>
                <div>
                    <p>
                        Email: {email}
                    </p>
                    <Email email={email} setEmail={setEmail}/>
                </div>
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

class HomePage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            counter: 0,
        }
    }

    handleClick = () => {
        this.setState({
            counter: this.state.counter + 1,
        });
    }


    render() {

        return (
            <div className="App">
                <header className="App-header">
                    <p>
                        Home Page
                    </p>
                    <div>
                        <p>
                            Counter: {this.state.counter}
                        </p>
                        <button onClick={this.handleClick}>
                            Click me
                        </button>
                    </div>
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
}

const Email = ({email, setEmail}) => {
    return (
        <input value={email} onChange={e => setEmail(e.target.value)}/>
    )
}

export default Home;
