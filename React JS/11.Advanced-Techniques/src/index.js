import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import Navigation from './navigation'
import App from "./App";
import {BrowserRouter} from "react-router-dom";

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <App {...window.__STATE__}>
            <BrowserRouter>
                <Navigation/>
            </BrowserRouter>
        </App>
    </React.StrictMode>
);

// ReactDOM.render(
//   <React.StrictMode>
//     <Navigation />
//   </React.StrictMode>,
//   document.getElementById('root')
// )

