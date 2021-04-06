function search() {
    let towns = document.querySelectorAll('#towns li');
    let input = document.getElementById('searchText').value;
    let result = 0;

    for (const town of towns) {
        if (town.textContent.includes(input)) {
            town.style.textDecoration = 'underline';
            town.style.fontWeight = 'bold';
            result++;
        } else {
            town.style.textDecoration = 'none';
            town.style.fontWeight = 'normal';
        }
    }

    document.getElementById('result').textContent =
        result > 1 ? `${result} matches found` : `${result} match found`;
}
