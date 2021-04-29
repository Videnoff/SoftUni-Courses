function solve() {
    document.getElementById("add").addEventListener("click", addTask);

    function addTask(e) {
        e.preventDefault();

        const task = document.getElementById("task").value;
        const description = document.getElementById("description").value;
        const date = document.getElementById("date").value;

        if (!task || !description || !date) {
            return;
        }

        const openSectionDivEl = document.querySelector("div > section:nth-child(2) > div:nth-child(2)");

        const article = createElement("article");
        const h3 = createElement("h3", task);
        const descrP = createElement("p", `Description: ${description}`);
        const dateP = createElement("p", `Due Date: ${date}`);
        const div = createElement("div");
        div.classList.add("flex");
        const startBtn = createElement("button", "Start");
        startBtn.classList.add("green");
        startBtn.addEventListener("click", moveToProgress);

        const deleteBtn = createElement("button", "Delete");
        deleteBtn.classList.add("red");
        deleteBtn.addEventListener("click", delArticle);

        div.appendChild(startBtn);
        div.appendChild(deleteBtn);

        article.appendChild(h3);
        article.appendChild(descrP);
        article.appendChild(dateP);
        article.appendChild(div);

        openSectionDivEl.appendChild(article);
    }

    function moveToProgress(e) {
        const divEl = e.target.parentElement;
        const articleEl = divEl.parentElement;

        const finishBtn = createElement("button", "Finish");
        finishBtn.classList.add("orange");
        finishBtn.addEventListener("click", moveToComplete);

        divEl.appendChild(finishBtn);
        e.target.remove();

        document.getElementById("in-progress").appendChild(articleEl);

    }

    function delArticle(e) {
        e.target.parentElement.parentElement.remove();
    }

    function moveToComplete(e) {

        document.querySelector("div > section:nth-child(4) > div:nth-child(2)").appendChild(e.target.parentElement.parentElement);
        e.target.parentElement.remove();
    }

    function createElement(element, content) {
        const newEl = document.createElement(element);

        if (content === undefined) {
            content = "";
        }

        if (element === "input" || element === "textarea") {
            newEl.value = content;
        } else {
            newEl.textContent = content;
        }

        return newEl;
    }
}