function solve() {
    let firstElement;
    let secondElement;
    let resultElement;
    return {
        init: (selector1, selector2, resultSelector) => {
            firstElement = document.querySelector(selector1);
            secondElement = document.querySelector(selector2);
            resultElement = document.querySelector(resultSelector);
        },
        add: () => {
            resultElement.value = Number(firstElement.value) + Number(secondElement.value)
        },
        subtract: () => {
            resultElement.value = Number(firstElement.value) - Number(secondElement.value)
        }
    }
}