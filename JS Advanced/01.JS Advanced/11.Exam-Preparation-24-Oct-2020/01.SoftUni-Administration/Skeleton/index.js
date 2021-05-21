function solve() {
    let formControls = document.querySelectorAll('.form-control input');
    let lecture = formControls[0];
    let date = formControls[1];
    let moduleName = document.querySelector('select');
    let modulesOutput = document.querySelector('.modules');

    const state = {};

    function createElement(type, text, attributes = []) {
        let element = document.createElement(type);

        if (text) {
            element.textContent = text;
        }

        attributes
            .map(attr => attr.split('='))
            .forEach(([name, value]) => {
                element.setAttribute(name, value);
            })

        return element;
    }

    function add(ev) {
        ev.preventDefault();

        if (lecture.value === ''
            || date.value === ''
            || moduleName === 'Select module') {
            return;
        }

        let lectureName = lecture.value;
        let dateString = date.value;


        let lectureTitle = lectureName + ' - ' + dateString.split('-').join('/').split('T').join(' - ');

        let delBtn = createElement('button', 'Del', ['class=red']);

        let lectureH4 = createElement('h4', lectureTitle);

        let li = createElement('li', undefined, ['class=flex']);

        li.appendChild(lectureH4);
        li.appendChild(delBtn);

        let module = undefined;
        let ul = undefined;
        if (!state[moduleName.value]) {
            let h3 = createElement('h3', `${moduleName.value.toUpperCase()}-MODULE`);
            ul = createElement('ul');
            module = createElement('div', undefined, ['class=module']);

            module.appendChild(h3);
            module.appendChild(ul);

            state[moduleName.value] = {module, ul, lis: []};
        } else {
            module = state[moduleName.value].module;
            ul = state[moduleName.value].ul;
        }

        state[moduleName.value].lis.push({li, date: date.value});
        state[moduleName.value].lis.sort((a, b) => a.date.localeCompare(b.date)).forEach(({li}) => {
            ul.appendChild(li);
        });

        modulesOutput.appendChild(module);
    }

    function del(ev) {
        let li = ev.target.parentNode;
        let ul = li.parentNode;
        let module = ul.parentNode;

        li.remove();

        if (ul.children.length === 0) {
            module.remove();
        }
    }

    document.getElementsByTagName('main')[0].addEventListener('click', (e) => {
        if (e.target.tagName === 'BUTTON') {
            if (!e.target.classList.contains('red')) {
                add(e);
            } else {
                del(e);
            }
        }
    })
}