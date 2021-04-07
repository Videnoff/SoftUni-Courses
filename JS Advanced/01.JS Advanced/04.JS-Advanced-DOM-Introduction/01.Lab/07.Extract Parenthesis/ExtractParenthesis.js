function extract(content) {
    let regX = new RegExp(/\([^)]*\)/g);

    let text = document.getElementById('content').textContent;
    let result = [];

    let word;

    while ((word = regX.exec(text)) !== null) {
        if (word.index === regX.lastIndex) {
            regX.lastIndex++;
        }

        word.forEach((match, groupIndex) => {
            result.push(word);
        });
    }

    return result.join('; ');
}