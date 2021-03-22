// function strLen(a, b, c) {
//     let total = 0;
//     total += a.length;
//     total += b.length;
//     total += c.length;

//     let average = Math.floor(total / 3);

//     console.log(total);
//     console.log(average);
// }

function strLen(...params) {
    let total = params.reduce((a, c) => a + c.length, 0);
    console.log(total);
    console.log(Math.floor(total / params.length));
}

strLen('chocolate', 'ice cream', 'cake');
strLen('pasta', '5', '22,3');