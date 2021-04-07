function solve() {
    let text = document.getElementById('input');
    let sentencesSpl = text.value.split('.');

    let sentences = [];


    for (let i = 0; i < sentencesSpl.length; i++) {
        if (sentencesSpl[i].length > 0) {
            sentences.push(sentencesSpl[i]);
        }
    }

    for (let i = 0; i < sentences.length; i += 3) {
        let result = [];
        for (let j = 0; j < 3; j++) {
            if (sentences[i + j]) {
                result.push(sentences[i + j]);
            }
        }

        let p = result.join('. ') + ".";
        document.getElementById('output').innerHTML += `<p>${p}</p>`;
    }
}