import React, {Component} from "react";

class Input extends Component {
    constructor(props) {
        super(props);

        this.state = {
            value: '',
        }
    }

    changeValue = (event) => {
        this.setState({
            value: event.target.value,
        })
    }

    componentDidMount() {
        // fetch()
    }

    render() {
        const {name} = this.props;

        if (!name) {
            return (
                <span>
                    Loading...
                </span>
            )
        }

        return (
            <div>
                <input onChange={this.changeValue} value={name}/>
                <p>
                    {this.state.value}
                </p>
            </div>)
    }

}

export default Input