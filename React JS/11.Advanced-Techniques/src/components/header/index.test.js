import React from 'react';
import renderer from 'react-test-renderer';
import Header from "./index";
import TestingEnvironment from "../../test-utils/router";


describe('Header Component', function () {
    it('should render authenticated routes', function () {
        const tree = renderer.create(
            <TestingEnvironment value={{
                user: {
                    loggedIn: true,
                    id: '123',
                }
            }}>
                <Header/>
            </TestingEnvironment>
        ).toJSON();
        expect(tree).toMatchSnapshot();
    });

    it('should render non-authenticated routes', function () {
        const tree = renderer.create(
            <TestingEnvironment value={{
                user: {
                    loggedIn: false,
                }
            }}>
                <Header/>
            </TestingEnvironment>
        ).toJSON();
        expect(tree).toMatchSnapshot();
    });
});