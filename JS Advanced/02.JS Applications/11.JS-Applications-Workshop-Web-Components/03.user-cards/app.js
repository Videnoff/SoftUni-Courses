import {html, render} from "../node_modules/lit-html/lit-html.js";
import {styleMap} from "../node_modules/lit-html/directives/style-map.js";

const template = (avatar, info, toggle) => html`
    <style>
        .user-card {
            display: flex;
            font-family: 'Arial', sans-serif;
            background-color: #EEE;
            border-bottom: 5px solid darkorchid;
            width: 100%;
        }

        .user-card img {
            width: 200px;
            height: 200px;
            border: 1px solid darkorchid;
        }

        .info {
            display: flex;
            flex-direction: column;
        }

        .info h3 {
            font-weight: bold;
            margin-top: 1em;
            text-align: center;
        }

        .info button {
            outline: none;
            border: none;
            cursor: pointer;
            background-color: darkorchid;
            color: white;
            padding: 0.5em 1em;
        }

        @media only screen and (max-width: 500px) {
            .user-card {
                flex-direction: column;
                margin-bottom: 1em;
            }

            .user-card figure,
            .info button {
                align-self: center;
            }

            .info button {
                margin-bottom: 1em;
            }

            .info p {
                padding-left: 1em;
            }
        }
    </style>
    <div class="user-card">
        <figure>
            <img src=${avatar} />
        </figure>
        <div class="info">
            <h3>
                <slot></slot>
            </h3>
            <div style=${styleMap({display: info ? '' : 'none'})}>
                <p>
                    <slot name="email" />
                </p>
                <p>
                    <slot name="phone" />
                </p>
            </div>

            <button @click=${toggle} class="toggle-info-btn">
                Toggle Info
            </button>
        </div>
    </div>
`;

class UserCard extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({mode: 'open'});
        this.avatar = this.getAttribute('avatar');
        this.info = false;
    }

    connectedCallback() {
        this.update();
    }

    toggleInfo() {
        this.info = !this.info;
        this.update();
    }

    update() {
        render(template(this.avatar, this.info, this.toggleInfo), this.shadowRoot, {eventContext: this});
    }
}

window.customElements.define('user-card', UserCard);
