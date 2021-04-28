function solve() {

    const cart = [];

    function onClick(ev) {
        document.querySelector('textarea').textContent +=
            `Added ${ev.target
                .parentNode
                .parentNode
                .querySelector('.product-title').textContent} for ${Number(ev.target
                .parentNode
                .parentNode
                .querySelector('.product-line-price').textContent).toFixed(2)} to the cart.\n`;

        const title = ev.target
            .parentNode
            .parentNode
            .querySelector('.product-title').textContent;

        const price = Number(ev.target
            .parentNode
            .parentNode
            .querySelector('.product-line-price').textContent);

        cart.push({
            title,
            price
        })
    }

    Array.from(document.querySelectorAll('.add-product'))
        .forEach(x => {
            x.addEventListener('click', onClick)
        });

    document.querySelector('.checkout').addEventListener('click', () => {
        const result = cart.reduce((a, c) => {
            a.items.add(c.title);
            a.total += c.price;
            return a;
        }, {items: new Set(), total: 0});

        document.querySelector('textarea').textContent += `You bought ${[...result.items].join(', ')} for ${result.total.toFixed(2)}.`;
    });
}