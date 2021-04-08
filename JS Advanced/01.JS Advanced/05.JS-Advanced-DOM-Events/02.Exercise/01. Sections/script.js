function create(words) {
    let content = document.getElementById('content');

    words.forEach(w => {
        let div = document.createElement('div');
        let paragraph = document.createElement('p');
        paragraph.textContent = w;
        paragraph.style.display = 'none';
        div.appendChild(paragraph);
        content.appendChild(div);
    });

    content.addEventListener('click', function (e) {
        if (e.target.tagName === 'DIV' || e.target.tagName === 'P') {
            const p = e.target.children[0] || e.target;
            const isVisible = p.style.display === 'block';
            p.style.display = isVisible ? 'none' : 'block';
        }
    })
}
