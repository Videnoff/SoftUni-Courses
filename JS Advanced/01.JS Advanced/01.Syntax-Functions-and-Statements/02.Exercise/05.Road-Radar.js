function solve(speed, area) {
    let motorwayLimit = 130;
    let interstateLimit = 90;
    let cityLimit = 50;
    let residentialLimit = 20;

    let result;
    let status;
    let difference = 0;

    switch (area) {
        case 'motorway':
            difference = speed - motorwayLimit;
            if (speed <= motorwayLimit) {
                result = `Driving ${speed} km/h in a ${motorwayLimit} zone`;
            } else {
                if (difference <= 20) {
                    status = 'speeding';
                } else if (difference <= 40) {
                    status = 'excessive speeding';
                } else {
                    status = 'reckless driving';
                }

                result = `The speed is ${difference} km/h faster than the allowed speed of ${motorwayLimit} - ${status}`;
            }
            break;
        case 'interstate':
            difference = speed - interstateLimit;
            if (speed <= interstateLimit) {
                result = `Driving ${speed} km/h in a ${interstateLimit} zone`;
            } else {
                if (difference <= 20) {
                    status = 'speeding';
                } else if (difference <= 40) {
                    status = 'excessive speeding';
                } else {
                    status = 'reckless driving';
                }

                result = `The speed is ${difference} km/h faster than the allowed speed of ${interstateLimit} - ${status}`;
            }
            break;
        case 'city':
            difference = speed - cityLimit;
            if (speed <= cityLimit) {
                result = `Driving ${speed} km/h in a ${cityLimit} zone`;
            } else {
                if (difference <= 20) {
                    status = 'speeding';
                } else if (difference <= 40) {
                    status = 'excessive speeding';
                } else {
                    status = 'reckless driving';
                }

                result = `The speed is ${difference} km/h faster than the allowed speed of ${cityLimit} - ${status}`;
            }
            break;
        case 'residential':
            difference = speed - residentialLimit;
            if (speed <= residentialLimit) {
                result = `Driving ${speed} km/h in a ${residentialLimit} zone`;
            } else {
                if (difference <= 20) {
                    status = 'speeding';
                } else if (difference <= 40) {
                    status = 'excessive speeding';
                } else {
                    status = 'reckless driving';
                }

                result = `The speed is ${difference} km/h faster than the allowed speed of ${residentialLimit} - ${status}`;
            }
            break;
    }

    return result;
}

console.log(solve(40, 'city'));
console.log(solve(21, 'residential'));
console.log(solve(120, 'interstate'));
console.log(solve(200, 'motorway'));