function solve(json) {
    let arr = JSON.parse(json);
    let outputArr = ['<table>'];
    outputArr.push(makeKeyRow(arr));

    arr.forEach(element => {
        outputArr.push(makeValueRow(element))
    });

    outputArr.push('</table>');

    function makeKeyRow(arr) {
        let result = ' <tr>';
        Object.keys(arr[0]).forEach(key => {
            result += `<th>${escapeHtml(key)}</th>`;
        });

        result += '</tr>';
        return result;
    }

    function makeValueRow(obj) {
        let result = ' <tr>';
        Object.values(obj).forEach(value => {
            result += `<td>${escapeHtml(value)}</td>`;
        });

        result += '</tr>';
        return result;
    }

    function escapeHtml(value) {
        return value
            .toString()
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }

    console.log(outputArr.join('\n'));
}

console.log(solve([
    {
        "Name": "Stamat",
        "Score": 5.5
    },
    {
        "Name": "Rumen",
        "Score": 6
    }]
));

console.log(solve([
    {
        "Name": "Pesho",
        "Score": 4,
        " Grade": 8
    },
    {
        "Name": "Gosho",
        "Score": 5,
        " Grade": 8
    },
    {
        "Name": "Angel",
        "Score": 5.50,
        " Grade": 10
    }]
));