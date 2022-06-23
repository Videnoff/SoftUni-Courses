import {html, render} from "./node_modules/lit-html/lit-html.js";

const elementTemplate = (title, description) => html`
    <style>
        h1 {
            color: red;
        }
    </style>
    <article>
        <h1>
            <slot name="title">
                Title
            </slot>
        </h1>
        <p>
            <slot>
                Description
            </slot>
        </p>
    </article>`;

class MyLitElement extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({mode: 'open'});
    }

    connectedCallback() {
        render(elementTemplate(), this.shadowRoot, {eventContext: this});
    }
}

window.customElements.define('card-element', MyLitElement);
