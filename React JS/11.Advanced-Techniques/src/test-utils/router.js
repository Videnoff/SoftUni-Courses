import {BrowserRouter, Route, Routes} from "react-router-dom";
import UserContext from "../Context";

const TestingEnvironment = ({value, children}) => {
    return (
        <BrowserRouter>
            <Routes>
                <Route element={
                    <UserContext.Provider value={value}>
                        {children}
                    </UserContext.Provider>}>
                </Route>
            </Routes>
        </BrowserRouter>
    )
}

export default TestingEnvironment;
