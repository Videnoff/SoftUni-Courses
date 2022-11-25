import React, {Component} from "react";

class Counter extends Component {
    constructor(props) {
        super(props);

        this.state = {
            counter: props.counter,
            example: "Example",

        }

        /*
        this.updateCounter = this.updateCounter.bind(this);
         */
    }

    updateCounter = () => {
        const {
            counter,
            example,
            // data: []
        } = this.state

        this.setState({
            counter: counter + 1,
            example: `${example}1`
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
        return (
            <div>
                Counter: {this.state.counter}
                <button onClick={this.updateCounter}>
                    Click me
                </button>
                <button onClick={this.submit}>
                    Submit
                </button>
                {this.state.data}
            </div>
        )
    }
}

export default Counter