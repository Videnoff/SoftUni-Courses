import React, {lazy, Suspense} from "react";
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Header from "./header";
import HomePage from "./HomePage";
import ControlledForm from "./ControlledForm";
import UncontrolledForm from "./UncontrolledForm";
// import SearchPage from "./Search";
// import ProductPage from "./ProductPage";

const ProductPage = lazy(() => import("./ProductPage"));
const Search = lazy(() => import("./Search"));

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
                    <Route path="/search" element={<Search/>}/>
                    <Route path="/product/:productname/:productid" element={<ProductPage/>}/>
                    <Route path="/form" element={<ControlledForm/>}/>
                    <Route path="/unform" element={<UncontrolledForm />}/>
                </Routes>
                </Suspense>
            </BrowserRouter>
        </>
    );
}

export default Navigation;