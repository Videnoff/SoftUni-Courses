function solve() {
    let text = document.getElementById('text').value;
    let convention = document.getElementById('naming-convention').value;
    let result = [];

    text = text.toLowerCase().split(' ');

    switch (convention) {
        case 'Camel Case':
            result.push(text[0]);
            for (let i = 1; i < text.length; i++) {
                let newWord = text[i][0].toUpperCase() + text[i].slice(1);
                result.push(newWord);
            }

            result = result.join('');
            document.getElementById('result').textContent = result;
            break;
        case 'Pascal Case':
            for (const word of text) {
                let newWord = word[0].toUpperCase() + word.slice(1);
                result.push(newWord);
            }

            result = result.join('');
            document.getElementById('result').textContent = result;
            break;
        default:
            document.getElementById('result').textContent = 'Error!';
            break;
    }
}