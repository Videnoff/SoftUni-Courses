import React, {lazy, Suspense} from "react";
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Header from "./header";
import HomePage from "./HomePage";
// import SearchPage from "./Search";
// import ProductPage from "./ProductPage";

const number = 10;

const Navigation = () => {
    return (
        <>
            <BrowserRouter>
                <Header/>
                <Suspense fallback={() => <h1>Loading...</h1>}>
                    <Routes>
                        <Route path="/" element={<HomePage number={number}/>}>
                        </Route>
                        <Route path="/search" component={lazy(() => import("./Search"))}/>
                        <Route path="/product/:productname/:productid" component={lazy(() => import("./ProductPage"))}/>
                    </Routes>
                </Suspense>
            </BrowserRouter>
        </>
    )
}

export default Navigation;