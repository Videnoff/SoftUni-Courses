import fetch from 'node-fetch';

const verifyAuth = () => {
    fetch('http://localhost9999/api/user/verify',
        {
            method: 'get',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': token,
                // 'Access-Control-Allow-Origin': '*',
            }
        }
    ).then(promise => {
        return promise.json();
    }).then(response => {
        req.user = response.user;
        next();
    }).catch(err => {
        console.log(err);
        next();
    })
}

export default verifyAuth;
