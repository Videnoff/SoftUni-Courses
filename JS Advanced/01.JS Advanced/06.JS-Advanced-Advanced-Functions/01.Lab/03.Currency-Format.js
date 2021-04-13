function currencyFormatter(separator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2,2);
    if (symbolFirst) return symbol + ' ' + result;
    else return result + ' ' + symbol;
}

function createFormatter(separator, symbol, symbolFirst, currencyFormatter){
    return format;

    function format(input){
        return currencyFormatter(separator, symbol, symbolFirst, input);
    }
}

let dollarFormatter = createFormatter(',', '$', true, currencyFormatter);

console.log(dollarFormatter(5345));
console.log(dollarFormatter(3.1429));
console.log(dollarFormatter(2.709));