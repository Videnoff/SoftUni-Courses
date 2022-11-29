import logo from './logo.svg';
import './App.css';
import Code from "./Code";
import React, {Component} from "react";
import LearnReact from "./LearnReact";
import Input from "./Input"
import Counters from "./Counters";
import getGithubData from "./services/index";
import AuthContext from "./context";

class ClassApp extends Component {
    constructor(props) {
        super(props);

        this.state = {
            authenticate: false,
            data: {},
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
            authenticate: !this.state.authenticate,
        })
    }

    renderCounters() {
    }

    getData = async () => {
        const data = await getGithubData();

        this.setState({
            data,
        });
    };

    componentDidMount() {
        this.getData();
    }

    render() {
        // if (this.state.isLoading) {
        //     return (
        //         <span>
        //             Loading......
        //         </span>
        //     )
        // }

        console.log(this.state.data)
        return (
            <div className="App">
                <header className="App-header">
                    <img src={logo} className="App-logo" alt="logo"/>
                    <Input name={this.state.data.name}/>
                    <div>
                        <p>
                            Class Component
                        </p>
                        <AuthContext.Provider value={{
                            loggedin: this.state.authenticate,
                            username: this.state.authenticate ? "Pesho" : "",
                        }}>
                            <Counters/>
                        </AuthContext.Provider>
                    </div>
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
