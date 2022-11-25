import logo from './logo.svg';
import './App.css';
import Code from "./Code";
import React, {Component} from "react";
import LearnReact from "./LearnReact";
import Input from "./Input"
import Counters from "./Counters";

class ClassApp extends Component {
    constructor(props) {
        super(props);

        this.state = {
            hideCounters: false,
            // isLoading: true,
        }

    }

    // componentDidMount() {
    //     setTimeout(() => {
    //         this.setState({
    //             isLoading: false,
    //         })
    //     }, 2000)
    // }

    toggleCounters = () => {
        this.setState({
            hideCounters: !this.state.hideCounters,
        })
    }

    renderCounters() {
    }

    render() {
        // if (this.state.isLoading) {
        //     return (
        //         <span>
        //             Loading......
        //         </span>
        //     )
        // }

        return (
            <div className="App">
                <header className="App-header">
                    <img src={logo} className="App-logo" alt="logo"/>
                    <Input/>
                    {this.state.hideCounters ? null : (
                        <div>
                            <p>
                                Class Component
                            </p>
                            <Counters />
                        </div>
                    )}
                    <p>
                        Edit
                        <Code number={this.props.number}>
                            <p>
                                src/App.js
                            </p>
                        </Code> and save to reload.
                    </p>
                    <LearnReact/>
                    <button onClick={this.toggleCounters}>
                        Toggle Counters
                    </button>
                </header>
            </div>
        );
    }
}

export default ClassApp;
