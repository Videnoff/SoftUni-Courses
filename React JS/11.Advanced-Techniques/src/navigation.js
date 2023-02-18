import React, {Suspense, useContext} from 'react'
import {
    Routes,
    Route, Navigate
} from 'react-router-dom'
import UserContext from "./Context";

// import Publications from './pages/publications'
// import ShareThoughtsPage from './pages/share-thoughts'
// import RegisterPage from './pages/register'
// import LoginPage from './pages/login'
// import ProfilePage from './pages/profile'
// import ErrorPage from './pages/error'

// const Navigation = () => {

//   return (
//     <BrowserRouter>
//       <Switch>
//         <Route path="/" exact component={Publications} />
//         <Route path="/share" component={ShareThoughtsPage} />
//         <Route path="/register" component={RegisterPage} />
//         <Route path="/login" component={LoginPage} />
//         <Route path="/profile/:userid" component={ProfilePage} />
//         <Route component={ErrorPage} />
//       </Switch>
//     </BrowserRouter>
//   )
// }

const LazyPublications = React.lazy(() => import('./pages/publications'))
const LazyShareThoughtsPage = React.lazy(() => import('./pages/share-thoughts'))
const LazyRegisterPage = React.lazy(() => import('./pages/register'))
const LazyLoginPage = React.lazy(() => import('./pages/login'))
const LazyProfilePage = React.lazy(() => import('./pages/profile'))
const LazyErrorPage = React.lazy(() => import('./pages/error'))
const LazyNavigation = () => {

    const context = useContext(UserContext);
    console.log(context);
    // const loggedIn = context.user.loggedIn;

    return (
        <Suspense fallback={<h1>
            Loading..
        </h1>
        }>
            <Routes>
                <Route path="/" exact element={<LazyPublications/>}/>
                <Route path="/share"
                    /*element={loggedIn ? (<LazyShareThoughtsPage/>) : (<Navigate to="/login"/>)}*/
                       element={<LazyShareThoughtsPage/>}>
                </Route>
                <Route path="/register" element={<LazyRegisterPage/>}/>
                <Route path="/login" element={<LazyLoginPage/>}/>
                <Route path="/profile/:userid" element={<LazyProfilePage/>}/>
                <Route element={<LazyErrorPage/>}/>
            </Routes>
        </Suspense>
    )
}

export default LazyNavigation