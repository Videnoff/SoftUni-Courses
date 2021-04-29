function solve() {
    document.querySelectorAll("td button")[0].addEventListener("click", check);
    document.querySelectorAll("td button")[1].addEventListener("click", clear);
    const resultEl = document.querySelector("#check p");
    const tableEl = document.querySelector("table");

    function check() {
        const rowEls = Array.from(document.querySelectorAll("tr")).slice(2);
        let isCorrect = true;
        const matrix = [];

        rowEls.forEach(row => {
            const inputEls = Array.from(row.querySelectorAll("td input"));
            const currentRow = [];

            inputEls.forEach(input => currentRow.push(Number(input.value)));

            matrix.push(currentRow);
        });

        matrix.forEach((row, i) => {
            if (!row.includes(1) || !row.includes(2) || !row.includes(3)) {
                isCorrect = false;
            }

            const col = [matrix[0][i], matrix[1][i], matrix[2][i]];

            if (!col.includes(1) || !col.includes(2) || !col.includes(3)) {
                isCorrect = false;
            }
        });

        if (isCorrect) {
            resultEl.textContent = "You solve it! Congratulations!";
            resultEl.style.color = "green";
            tableEl.style.border = "2px solid green";
        } else {
            resultEl.textContent = "NOP! You are not done yet...";
            resultEl.style.color = "red";
            tableEl.style.border = "2px solid red";
        }
    }

    function clear() {
        const inputFieldEls = Array.from(document.querySelectorAll("td input"));
        resultEl.textContent = "";
        tableEl.style.border = "";

        inputFieldEls.forEach(input => input.value = "");
    }
}