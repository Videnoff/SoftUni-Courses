function solve() {
    document.getElementById("quizzie").addEventListener('click', answers);

    const resultHeaderElement = document.querySelector('.results-inner h1');
    const correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
    let correctAnswersCounter = 0;

    function answers(e) {

        if (e.target.tagName !== "P") {
            return;
        }

        let currentSection = e.target.parentElement.parentElement.parentElement.parentElement;
        let nextSection = currentSection.nextElementSibling;
        const answer = e.target.innerHTML;

        if (correctAnswers.includes(answer)) {
            correctAnswersCounter++;
        }

        if (correctAnswersCounter < 3) {
            resultHeaderElement.textContent = `You have ${correctAnswersCounter} right answers`;
        } else {
            resultHeaderElement.textContent = `You are recognized as top JavaScript fan!`;
        }

        currentSection.style.display = "none";
        nextSection.style.display = "block";
    }
}
