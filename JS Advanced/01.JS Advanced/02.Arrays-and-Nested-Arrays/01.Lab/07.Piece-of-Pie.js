function solve(piesArr, start, end) {
    let newArr = [];
    for (let i = 0; i < piesArr.length - 1; i++) {
        newArr = piesArr.slice(piesArr.indexOf(start), piesArr.indexOf(end));

    }

    newArr.push(end);
    return newArr;
}

console.log(solve(['Pumpkin Pie',
        'Key Lime Pie',
        'Cherry Pie',
        'Lemon Meringue Pie',
        'Sugar Cream Pie'],
    'Key Lime Pie',
    'Lemon Meringue Pie'
));

console.log(solve(['Apple Crisp',
        'Mississippi Mud Pie',
        'Pot Pie',
        'Steak and Cheese Pie',
        'Butter Chicken Pie',
        'Smoked Fish Pie'],
    'Pot Pie',
    'Smoked Fish Pie'
));