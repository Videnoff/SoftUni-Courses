async function solution() {
    const main = document.getElementById('main');

    const url = `http://localhost:3030/jsonstore/advanced/articles/list`;

    const response = await fetch(url);
    const data = await response.json();

    data.forEach(a => {
        const accordionElement = createElement('div', '', ['class', 'accordion']);

        const headElement = createElement('div', '', ['class', 'head']);

        const spanElement = createElement('span', a.title);

        const buttonElement = createElement('button', 'More', ['class', 'button', 'id', a._id]);

        buttonElement.addEventListener('click', toggle);

        headElement.appendChild(spanElement);
        headElement.appendChild(buttonElement);

        const divElement = createElement('div', '', ['class', 'extra']);
        const p = createElement('p');

        divElement.appendChild(p);

        accordionElement.appendChild(headElement);
        accordionElement.appendChild(divElement);

        main.appendChild(accordionElement);
    });

    async function toggle(event) {
        const accordion = event.target.parentNode.parentNode;
        const id = event.target.id;

        const p = event.target.parentNode.parentNode.children[1].firstChild;
        const extra = event.target.parentNode.parentNode.children[1];

        const url = `http://localhost:3030/jsonstore/advanced/articles/details/${id}`;

        const response = await fetch(url);
        const data = await response.json();

        p.textContent = data.content;

        const inHidden = event.target.textContent == 'More';
        extra.style.display = inHidden ? 'block' : 'none';
        event.target.textContent = inHidden ? 'Less' : 'More';
    }

     function createElement(type, content, attributes = []) {
        const element = document.createElement(type);

        if (content) {
            element.textContent = content;
        }

        if (attributes.length > 0) {
            for (let i = 0; i < attributes.length; i += 2) {
                element.setAttribute(attributes[i], attributes[i + 1]);
            }
        }

        return element;
    }
}

solution();