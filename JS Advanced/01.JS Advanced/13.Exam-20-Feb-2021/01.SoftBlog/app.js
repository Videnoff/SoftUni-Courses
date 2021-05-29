function solve() {
    const postsSection = document.querySelector('main>section');
    const createBtn = document.querySelector('form>button');
    const inputAuthor = document.querySelector('#creator');
    const inputTitle = document.querySelector('#title');
    const inputCategory = document.querySelector('#category');
    const inputContent = document.querySelector('#content');
    const archivePlace = document.querySelector('.archive-section>ol');

    createBtn.addEventListener('click', (evt) => {
        evt.preventDefault();
        const titleValue = inputTitle.value;
        const art = createElement('article');
        const h1 = createElement('h1', inputTitle.value);
        const pCat = createElement('p', 'Category:');
        const strongCat = createElement('strong', inputCategory.value);
        const pCreator = createElement('p', 'Creator:');
        const strongCreat = createElement('strong', inputAuthor.value);
        const pCont = createElement('p', inputContent.value);
        const divBtn = createElement('div', undefined, 'buttons');
        const deleteBtn = createElement('button', 'Delete', 'btn delete');
        const archiveBtn = createElement('button', 'Archive', 'btn archive');

        divBtn.appendChild(deleteBtn);
        divBtn.appendChild(archiveBtn);
        pCreator.appendChild(strongCreat);
        pCat.appendChild(strongCat);
        art.appendChild(h1);
        art.appendChild(pCat);
        art.appendChild(pCreator);
        art.appendChild(pCont);
        art.appendChild(divBtn);
        postsSection.appendChild(art)

        deleteBtn.addEventListener('click', () => del(art));
        archiveBtn.addEventListener('click', () => {
            del(art);
            const li = createElement('li', titleValue);
            archivePlace.appendChild(li);
            sortLis();
        })
    })

    function sortLis() {
        Array.from(archivePlace.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(a => archivePlace.appendChild(a));
    }

    function del(item) {
        item.remove();
    }

    function createElement(type, content, className) {
        const result = document.createElement(type);
        result.textContent = content;
        if (className) {
            result.className = className;
        }

        return result;
    }
}
