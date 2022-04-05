// document.querySelector('form').addEventListener('submit', onRegisterSubmit);

async function onRegisterSubmit(event) {
    event.preventDefault();

    const formData = new FormData(event.target);

    const email = formData.get('email');
    const password = formData.get('password');
    const repass = formData.get('rePass');

    if (email === '' || password === '') {
        return alert('All fields are required!');
    } else if (password !== repass) {
        return alert('Passwords don\'t match!');
    }

    const response = await fetch('http://localhost:3030/users/register', {
        method: 'post',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({email, password})
    });

    if (response.ok === false) {
        const error = await response.json();
        return alert(error.message);
    }

    const data = await response.json();
    sessionStorage.setItem('userToken', data.accessToken);
    // window.location.pathname = '../../../01.Lab/02.Cookbook-Part-3/index.html';
    onSuccess();
}

let main;
let section;
let onSuccess;

export function setupRegister(mainTarget, sectionTarget, onSuccessTarget) {
    main = mainTarget;
    section = sectionTarget;
    onSuccess = onSuccessTarget;

    const form = section.querySelector('form');

    form.addEventListener('submit', (ev => {
        ev.preventDefault();
        const formData = new FormData(ev.target);
        onRegisterSubmit([...formData.entries()].reduce((p, [k, v]) => Object.assign(p, {[k]: v}), {}));
    }));
}

export function showRegister() {
    main.innerHTML = '';
    main.appendChild(section);
}