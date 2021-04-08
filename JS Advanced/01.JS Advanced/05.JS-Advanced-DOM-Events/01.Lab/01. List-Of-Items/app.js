function addItem() {
    let input = document.querySelector('#newItemText').value;

    let li = document.createElement('li');
    let items = document.querySelector('#items');
    li.textContent = input;
    items.appendChild(li);
    document.querySelector('#newItemText').value = '';
}
