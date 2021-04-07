function solve() {
    document.querySelector('#searchBtn').addEventListener('click', onClick);

    let input = document.querySelector('#searchField');
    let fields = document.querySelectorAll('tbody tr');
    let btn = document.querySelector('#searchBtn');

    function onClick() {
        for (const field of fields) {
            if (field.textContent.toLowerCase().includes(input.value.toLowerCase())) {
                field.classList.add('select');
            } else {
                field.classList.remove('select');
            }
        }
    }
}