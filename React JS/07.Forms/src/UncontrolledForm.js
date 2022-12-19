import React, {Component} from "react";
import Input from "./Input";

class UncontrolledForm extends Component {
    constructor(props) {
        super(props);

        this.emailInput = React.createRef();
        this.passwordInput = React.createRef();
        this.repasswordInput = React.createRef();
    }

    handleSubmit = (event) => {
        event.preventDefault();
        console.log("Email: ", this.emailInput.current.value);
        console.log("Password: ", this.passwordInput.current.value);
        console.log("RePassword: ", this.repasswordInput.current.value);
    }

    render() {

        return (
            <div>
                <h1>
                    Uncontrolled Form
                </h1>
                <form onSubmit={this.handleSubmit}>
                    <div>
                        <label htmlFor="email">
                            Email:
                            <input ref={this.emailInput} id="email" />
                        </label>
                    </div>
                    <div>
                        <label htmlFor="password">
                            Password:
                            <input ref={this.passwordInput} id="password" />
                        </label>
                    </div>
                    <div>
                        <label htmlFor="re-password">
                            Re-Password:
                            <input ref={this.repasswordInput} id="re-password" />
                        </label>
                    </div>
                    <button type="submit" /*onClick={this.handleSubmit}*/ >
                        Submit
                    </button>
                </form>
            </div>
        );
    }
}

export default UncontrolledForm;