export const settings = {
    host: ''
};

async function request(url, options) {
    try {
        const response = await fetch(url, options);

        if (response.ok == false) {
            const error = await response.json();
            throw new Error(error.message);
        }

        try {
            const data = await response.json();
            return data;
        } catch (err) {
            return response;
        }
    } catch (err) {
        //alert(err.message);
        throw err;
    }
}

function getOptions(method = 'get', body) {
    const options = {
        method,
        headers: {
            'X-Parse-Application-Id': 'g8zRPCsAiY3u9iNJjPq6O8SF0NPfjX8aGIuxAozS',
            'X-Parse-REST-API-Key': 'I1pLeWJK9ytcCrp0dd6p0LNRwgVr2ewWWJB5I3lq'
        }
    };

    const token = sessionStorage.getItem('authToken');
    if (token != null) {
        options.headers['X-Parse-Session-Token'] = token;
    }

    if (body) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }

    return options;
}

export async function get(url) {
    return await request(url, getOptions());
}

export async function post(url, data) {
    return await request(url, getOptions('post', data));
}

export async function put(url, data) {
    return await request(url, getOptions('put', data));
}

export async function del(url) {
    return await request(url, getOptions('delete'));
}

export async function login(email, password) {
    const result = await post(settings.host + '/users/login', { email, password });

    sessionStorage.setItem('username', result.username);
    sessionStorage.setItem('authToken', result.accessToken);
    sessionStorage.setItem('userId', result._id);

    return result;
}

export async function register(email, username, password) {
    const result = await post(settings.host + '/users', { email, username, password });

    sessionStorage.setItem('username', username);
    sessionStorage.setItem('authToken', result.sessionToken);
    sessionStorage.setItem('userId', result.objectId);

    return result;
}

export async function logout() {
    const result = await post(settings.host + '/logout');

    sessionStorage.removeItem('username');
    sessionStorage.removeItem('authToken');
    sessionStorage.removeItem('userId');

    return result;
}