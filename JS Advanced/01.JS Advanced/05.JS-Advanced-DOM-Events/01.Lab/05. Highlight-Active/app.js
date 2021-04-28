function focus() {

    Array.from(document.querySelectorAll('input')).forEach(x => {
        x.addEventListener('focus', onFocus);
        x.addEventListener('blur', onBlur);
    });

    function onFocus(ev) {
        ev.target.parentNode.className = 'focused';
    }

    function onBlur(ev) {
        ev.target.parentNode.className = 'blurred';
    }

}