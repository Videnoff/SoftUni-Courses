function solve() {
    let text = document.getElementById('input');
    let sentencesSpl = text.value.split('.');

    let result = [];
    let sentences = [];


    for (let i = 0; i < sentencesSpl.length; i++) {
        if (sentencesSpl[i].length >= 1) {
            sentences.push(sentencesSpl[i]);
        }
    }

    let count = 0;

    result.push(`<p>`);

    for (let i = 0; i < sentences.length; i++) {
        result.push(sentences[i] + '.');
        count++;
        if (count % 3 === 0) {
            result.push('\n') + `</p>`);
            result.push('\n') + `<p>`);
        }
    }

    result.push(`</p>`)

    document.getElementById('output').textContent = result.join('\n');
}