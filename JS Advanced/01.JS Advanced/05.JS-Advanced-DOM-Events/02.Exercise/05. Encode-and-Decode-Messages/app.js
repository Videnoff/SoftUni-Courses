function encodeAndDecodeMessages() {
    const textAreas = document.querySelectorAll('textarea');
    const buttons = document.querySelectorAll('button');

    const elements = {
        encode: {
            text: textAreas[0],
            btn: buttons[0],
            func: (char) => String.fromCharCode(char.charCodeAt(0) + 1),
        },
        decode: {
            text: textAreas[1],
            btn: buttons[1],
            func: (char) => String.fromCharCode(char.charCodeAt(0) - 1),
        }
    }

    document.getElementById('main').addEventListener('click', function (ev) {
        if (ev.target.tagName !== 'BUTTON') {
            return;
        }

        const type = ev.target.textContent
            .toLowerCase()
            .trim()
            .includes('encode') ? 'encode' : 'decode';

        let message = elements[type].text.value.split('').map(elements[type].func).join('');

        elements.encode.text.value = '';
        elements.decode.text.value = message;
    })
}