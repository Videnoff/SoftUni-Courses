function addItem() {
    let input = document.querySelector('#newText').value;
    let items = document.querySelector('#items');

    let li = document.createElement('li');
    li.textContent = input;

    let link = document.createElement('a');
    let linkText = document.createTextNode('[Delete]');

    link.appendChild(linkText);
    link.href = '#';

    link.addEventListener('click', deleteItem);

    li.appendChild(link);
    items.appendChild(li);

    document.querySelector('#newText').value = '';

    function deleteItem() {
        li.remove();
    }
}