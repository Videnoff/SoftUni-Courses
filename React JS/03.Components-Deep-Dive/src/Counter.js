import React, {Component} from "react";
import CounterLabel from "./CounterLabel";
import styles from './counter.module.css';
import AuthContext from "./context";

class Counter extends Component {
    constructor(props) {
        super(props);

        this.state = {
            counter: props.counter, example: "Example",

        }

        /*
        this.updateCounter = this.updateCounter.bind(this);
         */
    }

    updateCounter = () => {
        const {
            counter, example, // data: []
        } = this.state

        this.setState({
            counter: counter + 1, example: `${example}1`
        })

        console.log(counter);
    }

    // updateCounter() {
    //     const {
    //         counter,
    //         example,
    //     } = this.state
    //
    //     this.setState({
    //         counter: counter + 1,
    //         example: `${example}1`,
    //     })
    // }

    // submit = () => {
    //     fetch().then(data => {
    //         this.setState({
    //             data: data
    //         })
    //     })
    // }

    render() {
        return (<div className={styles.wrapper}>
            <CounterLabel counter={this.state.counter}/>
            <button onClick={this.updateCounter}>
                Click me {this.context.username}
            </button>
            <button onClick={this.submit}>
                Submit
            </button>
            {this.state.data}
        </div>);
    }
}

Counter.contextType = AuthContext;

export default Counter
