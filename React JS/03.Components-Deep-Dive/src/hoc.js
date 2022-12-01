import React, {Component} from "react";

function fetcher(WrapperComponent) {
    return class extends Component {
        componentDidMount() {
            // fetch()
        }

        render() {
            return (
                <WrapperComponent {...this.props}/>
            );
        }
    }
}

export default fetcher;