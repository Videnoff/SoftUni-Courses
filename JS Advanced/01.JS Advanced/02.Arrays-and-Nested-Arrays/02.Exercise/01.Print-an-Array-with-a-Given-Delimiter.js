function solve(myArr, delimeter) {
    let result = '';

    /**
     * 1:
     */
    // for (let i = 0; i < myArr.length; i++) {
    //     result += i == myArr.length - 1 ? myArr[i] : (myArr[i] + delimeter);        
    // }


    /**
     * 2:
     */
    // for (let i = 0; i < myArr.length; i++) {
    //     result += myArr[i];
    //     if (i != myArr.length - 1) {
    //         result += delimeter;
    //     }
    // }

    /**
     * 3:
     */

    return myArr.join(delimeter);
}

console.log(solve(['One',
    'Two',
    'Three',
    'Four',
    'Five'],
    '-'
));

console.log(solve(['How about no?',
    'I',
    'will',
    'not',
    'do',
    'it!'],
    '_'
))
