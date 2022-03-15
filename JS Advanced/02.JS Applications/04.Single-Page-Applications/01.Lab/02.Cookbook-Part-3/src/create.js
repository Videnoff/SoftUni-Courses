document.querySelector('form').addEventListener('submit', onCreateSubmit);

async function onCreateSubmit(event) {
    event.preventDefault();
    const formData = new FormData(event.target);

    const name = formData.get('name');
    const img = formData.get('img');
    const ingredients = formData
        .get('ingredients')
        .split('\n')
        .map(l => l.trim())
        .filter(l => l !== '');
    const steps = formData
        .get('steps')
        .split('\n')
        .map(l => l.trim())
        .filter(l => l !== '');

    const token = sessionStorage.getItem('userToken');

    const response = await fetch('http://localhost:3030/data/recipes', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': token
        },
        body: JSON.stringify({
            name,
            img,
            ingredients,
            steps
        })
    });

    if (response.ok !== true) {
        const error = await response.json();
        return alert(error.message);
    }

    // window.location.pathname = '../../../01.Lab/02.Cookbook-Part-3/index.html';
    onSuccess();
}

let main;
let section;
let onSuccess;

export function setupCreate(mainTarget, sectionTarget, onSuccessTarget) {
    main = mainTarget;
    section = sectionTarget;
    onSuccess = onSuccessTarget;

    const form = section.querySelector('form');

    form.addEventListener('submit', (ev => {
        ev.preventDefault();
        const formData = new FormData(ev.target);
        onCreateSubmit([...formData.entries()].reduce((p, [k, v]) => Object.assign(p, {[k]: v}), {}));
    }));
}

export function showCreate() {
    main.innerHTML = '';
    main.appendChild(section);
}