import { render } from "./node_modules/lit-html/lit-html.js";
import {contacts} from "./contacts.js";
import cardTemplate from "./card.js";

const container = document.getElementById('contacts');
container.addEventListener('click', onClick);

contacts.forEach(c => c.isVisible = false);
const result = contacts.map(cardTemplate);
render(result, container);

function onClick(event) {
    if (event.target.classList.contains('detailsBtn')) {
        const id = event.target.parentNode.querySelector('.details').id;
        const element = contacts.find(c => c.id == id);
        element.isVisible = !element.isVisible;
        const result = contacts.map(cardTemplate);
        render(result, container);
    }
}