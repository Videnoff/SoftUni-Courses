import React, {Component} from "react";
import styles from './counter-label.module.css'
import AuthContext from "./context";

class CounterLabel extends Component {
    constructor(props) {
        super(props);

        this.state = {
            counter: props.counter,
        }
    }

    static getDerivedStateFromProps(props) {
        return {
            counter: props.counter,
        }
    }

    render() {
        return (
            <span className={styles.wrapper}>
                Counter: {this.context.loggedin ? "Auth" : ""} : {this.props.counter}
            </span>
        )
    }
}

CounterLabel.contextType = AuthContext;

export default CounterLabel;