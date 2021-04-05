function extractText() {
    let elements = document.querySelectorAll('ul#items li');
    let area = document.querySelector('#result');

    for (const element of elements) {
        area.value += element.textContent + '\n';
    }
}