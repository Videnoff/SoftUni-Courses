function solve(myArr) {
    let result = [];
    for (let i = 0; i < myArr.length; i += 2) {
        result[result.length] = myArr[i];
    }

    console.log(result.join(' '));
}

solve(['20', '30', '40', '50', '60']);
