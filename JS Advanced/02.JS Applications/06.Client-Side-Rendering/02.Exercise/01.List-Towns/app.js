/*
add click listener
parse input
execute template
render result
 */

// data -> list

import {html, render} from '../node_modules/lit-html/lit-html.js';

const listTemplate = (data) => html`
<ul>
    ${data.map(t => html`<li>${t}</li>`)}
</ul>
`;

// add click listener
document.getElementById('btnLoadTowns').addEventListener('click', updateList);

function updateList(event) {
    event.preventDefault();
    // parse input
    const townsAsString = document.getElementById('towns').value;
    const root = document.getElementById('root');

    const towns = townsAsString.split(',').map(x => x.trim());

    // execute template
    const result = listTemplate(towns);

    // render result
    render(result, root);
}
