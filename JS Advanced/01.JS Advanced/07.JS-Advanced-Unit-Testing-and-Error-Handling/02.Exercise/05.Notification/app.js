function notify(message) {
    let notification = document.querySelector('#notification');
    notification.textContent = message;
    notification.style.display = 'block';
    notification.addEventListener('click', evt => {
        evt.target.style.display = 'none';
    });
}