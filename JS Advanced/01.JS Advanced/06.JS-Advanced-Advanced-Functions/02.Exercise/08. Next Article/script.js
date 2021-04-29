function getArticleGenerator(articles) {
    let base = articles;

    function submit() {
        if (base[0] !== undefined) {
            let div = document.getElementById('content');
            let el = document.createElement('article');
            el.textContent = base.shift();
            div.appendChild(el);
        }
    }

    return submit;
}
