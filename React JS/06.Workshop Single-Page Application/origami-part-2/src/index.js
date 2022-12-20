import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import Navigation from './navigation'

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <Navigation/>
    </React.StrictMode>
);

// ReactDOM.render(
//   <React.StrictMode>
//     <Navigation />
//   </React.StrictMode>,
//   document.getElementById('root')
// )

