function deleteByEmail() {
    let input = document.querySelector('input[name="email"]').value;

    let rows = document.querySelectorAll('table tr');

    for (let i = 1; i < rows.length; i++) {
        let cols = rows[i].children;

        if (cols[cols.length - 1].textContent === input) {
            let row = cols[cols.length - 1].parentNode;
            row.parentNode.removeChild(row);
            document.querySelector('#result').textContent = 'Deleted';
            return;
        }
    }

    document.querySelector('#result').textContent = 'Not found.';
}