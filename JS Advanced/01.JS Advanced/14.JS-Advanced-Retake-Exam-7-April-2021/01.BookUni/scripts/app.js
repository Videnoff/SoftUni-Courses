function solve() {
    let totalProfit = document.querySelector("body > h1:nth-child(3)");
    let [inpBook, inpYear, inpPrice] = Array.from(document.querySelectorAll("form > input"));
    const addBookBtn = document.querySelector("body > form > button");
    const oldBooks = document.querySelector("#results > div:nth-child(1) > div");
    const newBooks = document.querySelector("#results > div:nth-child(2) > div");
    let price = 0;

    addBookBtn.addEventListener('click', (e) => {
        e.preventDefault();
        correctInputCheck();
    });

    function correctInputCheck() {
        let year = Number(inpYear.value);
        let price = Number(inpPrice.value);
        let type = '';
        if (inpBook.value !== '' && year > 0 && price > 0) {
            if (year >= 2000) {
                type = 'new';
            } else {
                type = 'old';
            }
            bookToNew(type, year, price);
        }
    }

    function bookToNew(type, y, p) {
        let divBook = document.createElement('div');
        divBook.classList.add('book');

        let par = document.createElement('p');
        par.textContent = `${inpBook.value} [${y}]`;

        let buyBtn = document.createElement('button');
        buyBtn.textContent = `Buy it only for ${p.toFixed(2)} BGN`;
        buyBtn.addEventListener('click',  incrProfit);


        divBook.appendChild(par);
        divBook.appendChild(buyBtn);

        if (type === 'new') {
            let newBooksBtn = document.createElement('button');
            newBooksBtn.textContent = `Move to old section`;
            newBooksBtn.addEventListener('click', () => toOld(divBook, newBooksBtn, p));

            divBook.appendChild(newBooksBtn);

            newBooks.appendChild(divBook);
        } else {
            p = p * 0.85;
            buyBtn.textContent = `Buy it only for ${p.toFixed(2)} BGN`;
            oldBooks.appendChild(divBook);

        }

    }

    function incrProfit(e) {
        //Matching the current price
        let pr = Number(e.target.innerHTML.match(/\d+\.\d+/g).join(''));
        price += pr;
        totalProfit.textContent = `Total Store Profit: ${+price.toFixed(2)} BGN`;
        //Removing a div from ANY bookshelf
        let parent = e.target.parentNode.parentNode;
        let index = findIndex(Array.from(parent.children), e.target.parentNode);
        remElement(parent, index);

    }
    //Finding the index of the correct div child
    function findIndex(parent, child) {
        return parent.findIndex((e) => e === child);
    }
    //Removing a child from the parent div at the given index
    function remElement(parent, index) {
        parent.removeChild(parent.children[index]);
    }

    function toOld(child, btnToRemove, p) {
        //Decreasing the price when moved to old section
        p = p * 0.85;
        newBooks.removeChild(child);
        child.removeChild(btnToRemove);
        oldBooks.appendChild(child);
        child.lastChild.innerHTML = `Buy it only for ${p.toFixed(2)} BGN`;
    }
}