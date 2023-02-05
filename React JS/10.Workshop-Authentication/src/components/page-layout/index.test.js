import React from 'react';
import renderer from 'react-test-renderer';
import TestingEnvironment from "../../test-utils/router";
import PageLayout from "./index";

jest.mock('../header', () => 'Header');
jest.mock('../aside', () => 'Aside');
jest.mock('../footer', () => 'Footer');

describe('PageLayout Component', function () {
    it('should render pageLayout component', function () {
        const tree = renderer.create(
            <TestingEnvironment value={{
                user: {
                    loggedIn: true,
                    id: '123',
                }
            }}>
                <PageLayout/>
            </TestingEnvironment>
        ).toJSON();
        expect(tree).toMatchSnapshot();
    });
});