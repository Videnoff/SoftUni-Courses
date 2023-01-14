import React, {Component} from "react";
import Input from "./Input";

class ControlledForm extends Component {
    constructor(props) {
        super(props);

        this.state = {
            // email: 'Email',
            email: '',
            emailError: false,
            password: '',
            passwordError: false,
            rePassword: '',
            rePasswordError: false,
            imageUrl: null,
        };

        // this.changeEmail = this.changeEmail.bind(this);
    }

    changeEmail = value => {
        this.setState({
            email: value,
        });
    }

    changePassword = event => {
        this.setState({
            password: event.target.value,
        });
    }

    changeRePassword = event => {
        this.setState({
            rePassword: event.target.value,
        });
    }

    handleSubmit = (event) => {
        event.preventDefault();
        const {
            emailError,
            passwordError,
            rePasswordError,
        } = this.state;

        if (emailError || passwordError || rePasswordError) {
            console.log('There is an error!');

            return;
        }

        console.log('All good');
        this.props.history.push('/');
    }

    handleBlur = () => {
        if (!this.state.email.includes('@')) {
            console.log("Errorrrrr!");
            this.setState({
                emailError: true,
            });
        } else if (this.state.emailError) {
            this.setState({
                emailError: false,
            });
        }
    }

    handlePasswordBlur = () => {
        const {password} = this.state;
        if (password.length < 6) {
            this.setState({
                passwordError: true,
            })
        } else if (this.state.passwordError) {
            this.setState({
                passwordError: false,
            })
        }
    }

    handleRePasswordBlur = () => {
        const {password, rePassword} = this.state;
        if (password !== rePassword) {
            this.setState({
                rePasswordError: true,
            })
        } else if (this.state.passwordError) {
            this.setState({
                rePasswordError: false,
            })
        }
    }

    openWidget = () => {
        const widget = window.cloudinary.createUploadWidget({
            cloudName: "dycso6lij",
            uploadPreset: "softuni-react",
        }, (error, result) => {
            console.log('Error: ', error)
            console.log('Result: ', result)
            if (result.event === 'success') {
                this.setState({
                    imageUrl: result.info.url,
                });
            }
        });

        widget.open();
    }

    render() {
        const {
            email,
            emailError,
            password,
            passwordError,
            rePassword,
            rePasswordError,
            btnDisabled,
            imageUrl,
        } = this.state;

        return (
            <div>
                <h1>
                    Controlled Form
                </h1>
                {imageUrl ? (<img src={imageUrl}/>) : null}
                <button onClick={this.openWidget}>
                    Upload Image
                </button>
                <form onSubmit={this.handleSubmit}>
                    <Input error={emailError} id="email" label="Email" value={email} onBlur={this.handleBlur}
                           onChange={this.changeEmail}/>
                    <div>
                        <label htmlFor="password">
                            Password:
                            <input value={password} type="password" id="password" onBlur={this.handlePasswordBlur}
                                   onChange={this.changePassword}/>
                            {passwordError ? (<div>Password must be 6 or more characters</div>) : null}

                        </label>
                    </div>
                    <div>
                        <label htmlFor="re-password">
                            Re-Password:
                            <input value={rePassword} type="password" id="re-password"
                                   onBlur={this.handleRePasswordBlur}
                                   onChange={this.changeRePassword}/>
                            {rePasswordError ? (<div>Passwords don't match</div>) : null}
                        </label>
                    </div>
                    <button disabled={btnDisabled} type="submit" /*onClick={this.handleSubmit}*/ >
                        Submit
                    </button>
                </form>
            </div>
        );
    }
}

export default ControlledForm;