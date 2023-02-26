import React, {Component, useContext, useState} from 'react'
import Title from '../../components/title'
import SubmitButton from '../../components/button/submit-button'
import styles from './index.module.css'
import PageLayout from '../../components/page-layout'
import Input from '../../components/input';
import authenticate from "../../utils/authenticate";
import UserContext from "../../Context";
import { useNavigate } from 'react-router-dom';

const LoginPage = () => {

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const context = useContext(UserContext);
    const history = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();

        await authenticate('http://localhost:9999/api/user/login', {
            username,
            password,
        }, (user) => {
            context.logIn(user);
            history('/');
        }, (e) => {
            console.log('Error', e);
        });
    };

    return (
        <PageLayout>
            <form className={styles.container} onSubmit={handleSubmit}>
                <Title title="Login"/>
                <Input
                    value={username}
                    onChange={e => setUsername(e.target.value)}
                    label="Username"
                    id="username"
                />
                <Input
                    type="password"
                    value={password}
                    onChange={e => setPassword(e.target.value)}
                    label="Password"
                    id="password"
                />
                <SubmitButton title="Login"/>
            </form>
        </PageLayout>
    );
}

export default LoginPage